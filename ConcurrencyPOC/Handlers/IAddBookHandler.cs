using ConcurrencyPOC.DTOs;

namespace ConcurrencyPOC.Handlers;

public interface IAddBookHandler
{
    Task HandleRequestAsync(AddBookRequestDto addBookRequestDto);
}