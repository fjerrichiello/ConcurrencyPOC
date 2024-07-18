﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ConcurrencyPOC.Persistence.Models;

[Index(nameof(AuthorId), IsUnique = true)]
public class BookCount
{
    [Key]
    public int Id { get; set; }

    public required string AuthorId { get; set; }

    public required int Count { get; set; }

    [Timestamp]
    public uint? Version { get; set; }
}