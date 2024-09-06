using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConcurrencyPOC.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Models;

[Index(nameof(BookRequestMainId), nameof(Reason), IsUnique = true)]
public class BookRequestDeclineReason
{
    public BookRequestDeclineReason(Guid id, DeclineReason reason)
    {
        Id = id;
        Reason = reason;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    public DeclineReason Reason { get; set; }

    public Guid BookRequestMainId { get; set; }

    public BookRequest BookRequest { get; set; }
}