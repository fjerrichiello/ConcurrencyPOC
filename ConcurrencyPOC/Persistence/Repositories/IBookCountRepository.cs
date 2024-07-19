using ConcurrencyPOC.Domain.Models;

namespace ConcurrencyPOC.Persistence.Repositories;

public interface IBookCountRepository
{
    Task<BookCount?> GetBookCountForAuthor(string authorId);

    Task AddAsync(string authorId);

    Task IncrementCountAsync(Guid id);
}