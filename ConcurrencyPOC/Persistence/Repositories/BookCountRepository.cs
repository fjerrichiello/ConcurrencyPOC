using ConcurrencyPOC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Repositories;

public class BookCountRepository(ApplicationDbContext _context) : IBookCountRepository
{
    public async Task<BookCount?> GetBookCountForAuthor(string authorId)
    {
        var bookCount =
            await _context.BookCounts.FirstOrDefaultAsync(bc => bc.AuthorId.ToLower().Equals(authorId.ToLower()));
        return bookCount is null ? null : new BookCount(bookCount.AuthorId, bookCount.Count);
    }
}