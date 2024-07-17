using System.ComponentModel.DataAnnotations;

namespace ConcurrencyPOC.Persistence.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    public required string AuthorId { get; set; }

    public required string Title { get; set; }
}