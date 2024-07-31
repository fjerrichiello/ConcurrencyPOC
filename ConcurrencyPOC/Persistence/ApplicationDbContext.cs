using ConcurrencyPOC.Enums;
using ConcurrencyPOC.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql;

namespace ConcurrencyPOC.Persistence;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; } = null!;

    public virtual DbSet<Book> Books { get; set; } = null!;

    public virtual DbSet<BookRequest> BookRequests { get; set; } = null!;

    public virtual DbSet<BookRequestTwo> BookRequestTwos { get; set; } = null!;

    public virtual DbSet<BookCount> BookCounts { get; set; } = null!;

    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookRequest>()
            .Property(x => x.RequestType)
            .HasConversion<string>();

        modelBuilder.Entity<BookRequest>()
            .Property(x => x.ApprovalStatus)
            .HasConversion<string>();


        modelBuilder.Entity<BookRequest>()
            .HasIndex(b => new { b.AuthorId, b.Title, b.ApprovalStatus, b.RequestType })
            .IsUnique()
            .HasFilter("""
                       "ApprovalStatus" = 'Pending' and "RequestType" = 'Add'
                       """);

        modelBuilder.Entity<Book>()
            .HasIndex(b => new { b.AuthorId, b.Title })
            .IsUnique();

        modelBuilder.Entity<BookRequestTwo>()
            .Property(x => x.RequestType)
            .HasConversion<string>();

        modelBuilder.Entity<BookRequestTwo>()
            .Property(x => x.ApprovalStatus)
            .HasConversion<string>();

        modelBuilder.Entity<BookRequestTwo>()
            .HasIndex(b => new { b.AuthorId, b.Title, b.ApprovalStatus, b.RequestType, b.Count })
            .IsUnique()
            .HasFilter("""
                       "ApprovalStatus" = 'Pending' and "RequestType" = 'Add'
                       """);

        List<Author> authors =
        [
            new Author() { Id = 1, AuthorId = "Dr.Seuss" },
            new Author() { Id = 2, AuthorId = "Roald Dahl" },
            new Author() { Id = 3, AuthorId = "Beatrix Potter" },
            new Author() { Id = 4, AuthorId = "Maurice Sendak" },
            new Author() { Id = 5, AuthorId = "Eric Carle" },
            new Author() { Id = 6, AuthorId = "Shel Silverstein" },
            new Author() { Id = 7, AuthorId = "Judy Blume" }
        ];

        modelBuilder.Entity<BookRequest>()
            .PrimitiveCollection(c => c.DeclineReasons)
            .ElementType()
            .HasConversion<string>();

        modelBuilder.Entity<BookRequestDeclineReason>()
            .Property(c => c.Reason)
            .HasConversion<string>();

        modelBuilder.Entity<BookRequestDeclineReasonTwo>()
            .Property(c => c.Reason)
            .HasConversion<string>();

        modelBuilder.Entity<Author>()
            .HasData(authors);
    }
}