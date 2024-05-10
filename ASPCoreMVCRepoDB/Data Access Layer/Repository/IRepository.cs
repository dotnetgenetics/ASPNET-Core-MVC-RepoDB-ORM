using System.Collections.Generic;

namespace ASPCoreMVCRepoDB.Data_Access_Layer.Repository
{
   public interface IRepository<T> where T: class
   {
      T FindByID(int ID);
      IEnumerable<T> GetAll();
      int Add(T Entity);
      int Delete(T Entity);
      int Update(T Entity);
   }
}
