using ConcurrencyPOC.Domain.Models;
using ConcurrencyPOC.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Repositories;

public class BookRequestTwoRepository(ApplicationDbContext _context) : IBookRequestRepository
{
    public async Task<int> GetPendingAddRequestCountAsync(string authorId)
        => await _context.BookRequestTwos.CountAsync(x =>
            x.AuthorId.ToLower().Equals(authorId.ToLower())
            && x.ApprovalStatus == ApprovalStatus.Pending);

    public async Task AddAsync(BookRequest bookRequest)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _context.Database.ExecuteSqlRawAsync(InsertStatement(bookRequest.AuthorId, bookRequest.Title));

            await transaction.CommitAsync();
        }
        catch
        {
            //Error
        }
    }

    public async Task<bool> PendingExistsAsync(string authorId, string title)
        => await _context.BookRequestTwos.AnyAsync(x =>
            x.AuthorId.ToLower().Equals(authorId.ToLower())
            && x.Title.ToLower().Equals(title.ToLower())
            && x.ApprovalStatus == ApprovalStatus.Pending);


    private string InsertStatement(string authorId, string title)
    {
        return $"""
                        INSERT INTO "BookRequestTwos" ("AuthorId", "Title", "RequestType", "ApprovalStatus", "Count") 
                        SELECT '{authorId}', '{title}', 'Add', 'Pending', total_count + 1
                        FROM (
                        SELECT (SELECT COUNT(*) AS A
                                     FROM "BookRequestTwos"
                                     WHERE "AuthorId" = '{authorId}'
                                     AND "ApprovalStatus" = 'Pending'
                                     AND "RequestType" = 'Add') +
                                (SELECT COUNT(*) AS A
                                     FROM "Books"
                                     WHERE "AuthorId" = '{authorId}') as total_count)
                                     AS subquery
                                     WHERE total_count < 3
                """;
    }
}