using ASPCoreMVCRepoDB.Data_Access_Layer.Repository;
using ASPCoreMVCRepoDB.Models;

namespace ASPCoreMVCRepoDB.Data_Access_Layer.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
   {
      public IRepository<Athletes> AthletesRepository { get; private set; }

      public UnitOfWork(IRepository<Athletes> repository)
      {
         this.AthletesRepository = repository;
      }
   }
}
