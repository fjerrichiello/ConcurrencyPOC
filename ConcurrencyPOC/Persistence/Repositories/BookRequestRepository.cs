using ConcurrencyPOC.Domain.Models;
using ConcurrencyPOC.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Repositories;

public class BookRequestRepository(ApplicationDbContext _context) : IBookRequestRepository
{
    public async Task<int> GetPendingAddRequestCountAsync(string authorId)
        => await _context.BookRequests.CountAsync(x =>
            x.AuthorId.ToLower().Equals(authorId.ToLower())
            && x.ApprovalStatus == ApprovalStatus.Pending);

    public async Task AddAsync(BookRequest bookRequest)
        => await _context.BookRequests.AddAsync(new Models.BookRequest()
        {
            AuthorId = bookRequest.AuthorId,
            Title = bookRequest.Title,
            RequestType = bookRequest.RequestType,
            ApprovalStatus = ApprovalStatus.Pending
        });

    public async Task<bool> PendingExistsAsync(string authorId, string title)
        => await _context.BookRequests.AnyAsync(x =>
            x.AuthorId.ToLower().Equals(authorId.ToLower())
            && x.Title.ToLower().Equals(title.ToLower())
            && x.ApprovalStatus == ApprovalStatus.Pending);
}