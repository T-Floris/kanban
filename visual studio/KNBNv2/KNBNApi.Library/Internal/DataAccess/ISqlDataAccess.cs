using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.Internal.DataAccess
{
    public interface ISqlDataAccess
    {
        // get connention string to use 
        string GetConnectionString(string connectionString);
        // need to be hear
        void Dispose();


        List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        void SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        void UpdateData<T>(string storedProcedure, T parameters, string connectionStringName);


        void UpdateUserEmail<T>(string storedProcedure, T parameters, string connectionStringName);

        //


        //void CommitTransaction();
        //List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
        //void RollbackTransaction();
        //void SaveDataInTransaction<T>(string storedProcedure, T parameters);
        //void StartTransaction(string connectionStringName);

    }
}
