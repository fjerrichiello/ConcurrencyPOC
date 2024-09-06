using ConcurrencyPOC.Enums;

namespace ConcurrencyPOC.Domain.Models;

public record EditBookRequest(string AuthorId, string Title, string NewTitle);