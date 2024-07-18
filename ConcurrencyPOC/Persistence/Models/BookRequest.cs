using System.ComponentModel.DataAnnotations;
using ConcurrencyPOC.Enums;

namespace ConcurrencyPOC.Persistence.Models;

public class BookRequest
{
    [Key]
    public int Id { get; set; }

    public required string AuthorId { get; set; }

    public required string Title { get; set; }

    public RequestType RequestType { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }
}