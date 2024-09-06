using ConcurrencyPOC.Enums;

namespace ConcurrencyPOC.Domain.Models;

public record AddBookRequest(string AuthorId, string Title);