using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        void CommitTransaction();
        void Dispose();
        string GetConnectionString(string connectionString);
        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
        void RollbackTransaction();
        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        void SaveDataInTransaction<T>(string storedProcedure, T parameters);
        void StartTransaction(string connectionStringName);
    }
}
