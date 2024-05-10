using ASPCoreMVCRepoDB.Data_Access_Layer.Repository;
using ASPCoreMVCRepoDB.Models;

namespace ASPCoreMVCRepoDB.Data_Access_Layer.UnitOfWork
{
   public interface IUnitOfWork
   {
      IRepository<Athletes> AthletesRepository { get; }
   }
}
