using ConcurrencyPOC.Domain.Models;

namespace ConcurrencyPOC.Persistence.Repositories;

public interface IBookRequestRepository
{
    Task<int> GetPendingAddRequestCountAsync(string authorId);

    Task AddAsync(BookRequest bookRequest);

    Task<bool> PendingExistsAsync(string authorId, string title);
}