using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ConcurrencyPOC.Endpoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapPost("/add-book-request", AddBookRequest);
        app.MapPost("/add-book-request-two", AddBookRequestTwo);
    }

    private static async Task AddBookRequest(HttpContext context,
        [FromKeyedServices("One")]
        IAddBookHandler _addBookHandler,
        [FromBody]
        AddBookRequestDto addBookRequestDto)
        => await _addBookHandler.HandleRequestAsync(addBookRequestDto);

    private static async Task AddBookRequestTwo(HttpContext context,
        [FromKeyedServices("Two")]
        IAddBookHandler _addBookHandler,
        [FromBody]
        AddBookRequestDto addBookRequestDto)
        => await _addBookHandler.HandleRequestAsync(addBookRequestDto);
}