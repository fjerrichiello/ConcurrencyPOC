using ConcurrencyPOC.Domain.Models;
using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Enums;
using ConcurrencyPOC.Exceptions;
using ConcurrencyPOC.Persistence.Repositories;
using ConcurrencyPOC.Persistence.UnitOfWork;

namespace ConcurrencyPOC.Handlers;

public class AddBookHandlerTwo(
    IBookRepository _bookRepository,
    IBookRequestTwoRepository _bookRequestTwoRepository,
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
            await _bookRequestTwoRepository.AddAsync(new BookRequest(addBookRequestDto.AuthorId,
                addBookRequestDto.Title,
                RequestType.Add));

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
            await _bookRequestTwoRepository.GetPendingAddRequestCountAsync(authorId);

        var books = await _bookRepository.GetCountAsync(authorId);

        return addRequestCount + books;
    }

    private async Task<bool> DoesExist(string authorId, string title)
    {
        var requestExists = await _bookRequestTwoRepository.PendingExistsAsync(authorId, title);
        var bookExists = await _bookRepository.ExistsAsync(authorId, title);
        return requestExists || bookExists;
    }
}