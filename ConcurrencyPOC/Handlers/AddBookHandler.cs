using ConcurrencyPOC.Domain.Models;
using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Enums;
using ConcurrencyPOC.Exceptions;
using ConcurrencyPOC.Persistence.Repositories;
using ConcurrencyPOC.Persistence.UnitOfWork;

namespace ConcurrencyPOC.Handlers;

public class AddBookHandler(
    IBookRepository _bookRepository,
    [FromKeyedServices("Two")]
    IBookRequestRepository _bookRequestRepository,
    IBookCountRepository _bookCountRepository,
    IUnitOfWork _unitOfWork) : IAddBookHandler
{
    public async Task HandleRequestAsync(AddBookRequestDto addBookRequestDto)
    {
        var success = await SubmitRequest(addBookRequestDto);
        var count = 0;

        while ((success is not null && success != true) || count <= 2)
        {
            success = await SubmitRequest(addBookRequestDto);
            count++;
        }

        if (success == null)
        {
            Console.WriteLine("MAXED OUT");
        }
    }

    private async Task<bool?> SubmitRequest(AddBookRequestDto addBookRequestDto)
    {
        try
        {
            var bookCount = await _bookCountRepository.GetBookCountForAuthor(addBookRequestDto.AuthorId);
            var count = bookCount?.Count ?? await GetTotalRequestsAndBooks(addBookRequestDto.AuthorId);

            if (count == 3)
                return null;

            if (bookCount is null)
            {
                await _bookCountRepository.AddAsync(addBookRequestDto.AuthorId);
                //Add request we know none exist
                await _bookRequestRepository.AddAsync(new BookRequest(addBookRequestDto.AuthorId,
                    addBookRequestDto.Title,
                    RequestType.Add));
            }
            else
            {
                if (!await DoesExist(addBookRequestDto.AuthorId, addBookRequestDto.Title))
                {
                    await _bookCountRepository.IncrementCountAsync(bookCount.Id);

                    await _bookRequestRepository.AddAsync(new BookRequest(addBookRequestDto.AuthorId,
                        addBookRequestDto.Title,
                        RequestType.Add));
                }
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }
        catch (ConcurrentUpdateException e)
        {
            Console.WriteLine(e);
            return false;
        }
    }


    private async Task<int> GetTotalRequestsAndBooks(string authorId)
    {
        var addRequestCount =
            await _bookRequestRepository.GetPendingAddRequestCountAsync(authorId);

        var books = await _bookRepository.GetCountAsync(authorId);

        return addRequestCount + books;
    }

    private async Task<bool> DoesExist(string authorId, string title)
    {
        var requestExists = await _bookRequestRepository.PendingExistsAsync(authorId, title);
        var bookExists = await _bookRepository.ExistsAsync(authorId, title);
        return requestExists || bookExists;
    }
}