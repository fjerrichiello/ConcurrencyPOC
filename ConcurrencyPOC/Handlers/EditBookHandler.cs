﻿using ConcurrencyPOC.Domain.Models;
using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Enums;
using ConcurrencyPOC.Exceptions;
using ConcurrencyPOC.Persistence.Repositories;
using ConcurrencyPOC.Persistence.UnitOfWork;
using Dumpify;

namespace ConcurrencyPOC.Handlers;

public class EditBookHandler(
    IBookRepository _bookRepository,
    [FromKeyedServices("One")]
    IBookRequestRepository _bookRequestRepository,
    IUnitOfWork _unitOfWork) : IEditBookHandler
{
    public async Task HandleRequestAsync(EditBookRequestDto editBookRequestDto)
    {
        await _bookRequestRepository.AddEditBookRequestAsync(new EditBookRequest(editBookRequestDto.AuthorId,
            editBookRequestDto.Title, editBookRequestDto.NewTitle));

        await _unitOfWork.CompleteAsync();
    }

    private async Task<bool> DoesExist(string authorId, string title)
    {
        var requestExists = await _bookRequestRepository.PendingExistsAsync(authorId, title);
        var bookExists = await _bookRepository.ExistsAsync(authorId, title);
        return requestExists || bookExists;
    }
}