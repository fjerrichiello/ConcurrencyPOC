namespace ConcurrencyPOC.DTOs;

public record EditBookRequestDto(string AuthorId, string Title, string NewTitle);