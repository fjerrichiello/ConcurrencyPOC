using ConcurrencyPOC.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    public virtual DbSet<BookRequest> BookRequests { get; set; } = null!;
    
    public virtual DbSet<BookCount> BookCounts { get; set; } = null!;

    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}