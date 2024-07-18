using ConcurrencyPOC.Persistence.Repositories;
using ConcurrencyPOC.Persistence.UnitOfWork;

namespace ConcurrencyPOC.Handlers;

public class AddBookHandler(
    IBookRepository _bookRepository,
    IBookRequestRepository _bookRequestRepository,
    IUnitOfWork _unitOfWork) : IAddBookHandler
{
    
    
    
}