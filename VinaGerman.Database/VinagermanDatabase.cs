using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;

namespace VinaGerman.Database
{
    public class VinagermanDatabase : IDisposable
    {
        public static string CONNECTION_STRING = "DefaultConnection";
        private Microsoft.Practices.EnterpriseLibrary.Data.Database _database = null;
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        public static VinagermanDatabase GetDatabaseInstance()
        {            
            return new VinagermanDatabase();
        }

        public VinagermanDatabase()
        {
            // Configure the DatabaseFactory to read its configuration from the .config file            
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            // Create a Database object from the factory using the connection string name.
            _database = factory.Create(CONNECTION_STRING);            
        }

        #region protected methods        
        #endregion

        #region public methods
        public T Resolve<T>(bool createNew = true) where T : IBaseDB
        {
            var dbInstance = Factory.Resolve<T>(createNew);
            dbInstance.Connection = this.Connection;
            dbInstance.Transaction = this.Transaction;
            dbInstance.DatabaseProvider = _database;
            return dbInstance;
        }
        public void OpenConnection()
        {
            if (Connection == null) Connection = _database.CreateConnection();
            if (Connection.State == ConnectionState.Closed) Connection.Open();
        }
        public void CloseConnection()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
        }
        public void BeginTransaction()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                if (Transaction == null) Transaction = Connection.BeginTransaction();
            }
            else
            {
                throw new Exception("The connection is not opened yet!");
            }            
        }
        public void CommitTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
            }
        }
        public void RollbackTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }
        #endregion

        public void Dispose()
        {
            if (Connection != null) CloseConnection();
        }
    }
}
