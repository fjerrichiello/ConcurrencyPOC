namespace ConcurrencyPOC.Exceptions;

public class ConcurrentUpdateException(string message) : Exception(message);