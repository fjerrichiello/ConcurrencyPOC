using ConcurrencyPOC.Enums;

namespace ConcurrencyPOC.Domain.Models;

public record BookRequest(string AuthorId, string Title, RequestType RequestType);