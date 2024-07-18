namespace ConcurrencyPOC.Persistence.UnitOfWork;

public interface IUnitOfWork
{
    Task CompleteAsync();
}