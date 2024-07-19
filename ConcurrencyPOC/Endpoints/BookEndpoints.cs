using ConcurrencyPOC.DTOs;
using ConcurrencyPOC.Handlers;
using Dumpify;
using Microsoft.AspNetCore.Mvc;

namespace ConcurrencyPOC.Endpoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapPost("/add-book-request", AddBookRequest);
        app.MapPost("/add-book-request-two", AddBookRequestTwo);
    }

    // private static async Task AddBookRequest(HttpContext context,
    //     [FromKeyedServices("One")]
    //     IAddBookHandler _addBookHandler,
    //     [FromBody]
    //     AddBookRequestDto addBookRequestDto)
    // {
    //     try
    //     {
    //         await _addBookHandler.HandleRequestAsync(addBookRequestDto);
    //     }
    //     catch (Exception e)
    //     {
    //         await Task.Delay(5000);
    //         await _addBookHandler.HandleRequestAsync(addBookRequestDto);
    //     }
    // }

    private static async Task AddBookRequest(HttpContext context,
        IServiceScopeFactory _factory,
        [FromBody]
        AddBookRequestDto addBookRequestDto)
    {
        try
        {
            var addBookHandler = _factory.CreateAsyncScope().ServiceProvider.GetKeyedService<IAddBookHandler>("One");
            await addBookHandler!.HandleRequestAsync(addBookRequestDto);
        }
        catch (Exception e)
        {
            e.Dump();
            var addBookHandler = _factory.CreateAsyncScope().ServiceProvider.GetKeyedService<IAddBookHandler>("One");
            await addBookHandler!.HandleRequestAsync(addBookRequestDto);
        }
    }

    private static async Task AddBookRequestTwo(HttpContext context,
        [FromKeyedServices("Two")]
        IAddBookHandler _addBookHandler,
        [FromBody]
        AddBookRequestDto addBookRequestDto)
        => await _addBookHandler.HandleRequestAsync(addBookRequestDto);
}