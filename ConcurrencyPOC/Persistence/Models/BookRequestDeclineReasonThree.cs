using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConcurrencyPOC.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Models;

[PrimaryKey(nameof(BookRequestId), nameof(Reason))]
public class BookRequestDeclineReasonThree
{
    public BookRequestDeclineReasonThree(DeclineReason reason)
    {
        Reason = reason;
    }

    public Guid BookRequestId { get; set; }

    public DeclineReason Reason { get; set; }

    public BookRequest BookRequest { get; set; }
}