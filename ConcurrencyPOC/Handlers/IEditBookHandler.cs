using ConcurrencyPOC.DTOs;

namespace ConcurrencyPOC.Handlers;

public interface IEditBookHandler
{
    Task HandleRequestAsync(EditBookRequestDto editBookRequestDto);
}