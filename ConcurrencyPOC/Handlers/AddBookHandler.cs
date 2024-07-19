using ConcurrencyPOC.Domain.Models;
using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Enums;
using ConcurrencyPOC.Exceptions;
using ConcurrencyPOC.Persistence.Repositories;
using ConcurrencyPOC.Persistence.UnitOfWork;
using Dumpify;

namespace ConcurrencyPOC.Handlers;

public class AddBookHandler(
    IBookRepository _bookRepository,
    [FromKeyedServices("One")]
    IBookRequestRepository _bookRequestRepository,
    IBookCountRepository _bookCountRepository,
    IUnitOfWork _unitOfWork) : IAddBookHandler
{
    public async Task HandleRequestAsync(AddBookRequestDto addBookRequestDto)
    {
        try
        {
            var success = await SubmitRequest(addBookRequestDto);
            success.Dump();
        }
        catch (Exception e)
        {
            var successError = await SubmitRequest(addBookRequestDto);
            successError.Dump();
            throw;
        }
    }

    private async Task<bool?> SubmitRequest(AddBookRequestDto addBookRequestDto)
    {
        var bookCount = await _bookCountRepository.GetBookCountForAuthor(addBookRequestDto.AuthorId);
        Console.WriteLine(bookCount);
        var count = bookCount?.Count ?? 0;

        if (count == 3)
            return null;

        if (count == 0)
        {
            await _bookCountRepository.AddAsync(addBookRequestDto.AuthorId);
            //Add request we know none exist
            await _bookRequestRepository.AddAsync(new BookRequest(addBookRequestDto.AuthorId,
                addBookRequestDto.Title,
                RequestType.Add));

            await _unitOfWork.CompleteAsync();
            return true;
        }

        if (await DoesExist(addBookRequestDto.AuthorId, addBookRequestDto.Title)) return null;

        await _bookCountRepository.IncrementCountAsync(bookCount!.Id);

        await _bookRequestRepository.AddAsync(new BookRequest(addBookRequestDto.AuthorId,
            addBookRequestDto.Title,
            RequestType.Add));

        await _unitOfWork.CompleteAsync();
        return true;
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