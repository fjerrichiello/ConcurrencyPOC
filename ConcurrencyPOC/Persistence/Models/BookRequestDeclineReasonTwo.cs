using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ConcurrencyPOC.Enums;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Models;

public class BookRequestDeclineReasonTwo
{
    public BookRequestDeclineReasonTwo(DeclineReason reason)
    {
        Reason = reason;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DeclineReason Reason { get; set; }
}