using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConcurrencyPOC.Enums;

namespace ConcurrencyPOC.Persistence.Models;

public class BookRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid MainId { get; init; }

    public required string AuthorId { get; set; }

    public required string Title { get; set; }

    public RequestType RequestType { get; set; }

    public ApprovalStatus ApprovalStatus { get; set; }

    public IEnumerable<DeclineReason>? DeclineReasons { get; set; }


    public IEnumerable<BookRequestDeclineReason>? DeclineReasons2 { get; set; }

    public IEnumerable<BookRequestDeclineReasonTwo>? DeclineReasonsTwo { get; set; }
}