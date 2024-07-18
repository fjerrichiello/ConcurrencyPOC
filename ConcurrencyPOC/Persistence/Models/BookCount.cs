using System.ComponentModel.DataAnnotations;

namespace ConcurrencyPOC.Persistence.Models;

public class BookCount
{
    [Key]
    public int Id { get; set; }

    public required string AuthorId { get; set; }

    public required int Count { get; set; }

    [Timestamp]
    public uint? Version { get; set; }
}