using System.ComponentModel.DataAnnotations;
using ConcurrencyPOC.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Models;


public class BookRequestTwo
{
    [Key]
    public int Id { get; set; }

    public required string AuthorId { get; set; }

    public required string Title { get; set; }

    public RequestType RequestType { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }
    
    public required int Count { get; set; }
    
    [Timestamp]
    public uint? Version { get; set; }
}