using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ConcurrencyPOC.Endpoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapPost("/add-book-request", AddBookRequest);
    }

    private static Task AddBookRequest(HttpContext context, IAddBookHandler _addBookHandler,
        [FromBody] AddBookRequestDto addBookRequestDto)
    {
        throw new NotImplementedException();
    }
}