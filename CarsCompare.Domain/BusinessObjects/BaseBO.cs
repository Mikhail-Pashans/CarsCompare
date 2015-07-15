using CarsCompare.Database;

namespace CarsCompare.Domain.BusinessObjects
{
    public abstract class BaseBO
    {
        internal IUnitOfWork UnitOfWork;        

        protected BaseBO(IUnitOfWork uow)
        {
            UnitOfWork = uow;            
        }
    }
}