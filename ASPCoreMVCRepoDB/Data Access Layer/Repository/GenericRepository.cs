using Microsoft.Extensions.Configuration;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ASPCoreMVCRepoDB.Data_Access_Layer.Repository
{
   public class GenericRepository<T> : IRepository<T> where T : class
   {
      private readonly IConfiguration _configuration;
      private readonly string connectionString;

      public GenericRepository(IConfiguration configuration)
      {
         _configuration = configuration;
         connectionString = _configuration.GetConnectionString("ASPCoreRepoDB");
      }

      public int Add(T Entity)
      {
         int id = 0;

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               id = (int)connection.Insert<T>(Entity);
            }
         }
         catch (Exception ex)
         {
            return -1;
         }

         return id;
      }

      public int Update(T Entity)
      {
         int affectedRows = 0;

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               affectedRows = (int)connection.Update<T>(Entity);
            }
         }
         catch (Exception ex)
         {
            return -1;
         }

         return affectedRows;
      }

      public int Delete(T Entity)
      {
         int affectedRows = 0;

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               affectedRows = (int)connection.Delete<T>(Entity);
            }
         }
         catch (Exception ex)
         {
            return -1;
         }

         return affectedRows;
      }

      public T FindByID(int ID)
      {
         T result;

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               result = connection.Query<T>(ID).FirstOrDefault();
            }
         }
         catch (Exception ex)
         {
            return null;
         }

         return result;
      }

      public IEnumerable<T> GetAll()
      {
         List<T> lstAthletes;

         lstAthletes = new List<T>();

         try
         {
            using (var connection = new SqlConnection(this.connectionString))
            {
               connection.Open();
               lstAthletes = connection.QueryAll<T>().ToList();
            }
         }
         catch (Exception ex)
         {
            return null;
         }

         return lstAthletes;
      }
   }
}