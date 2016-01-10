using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace VinaGerman.Database.Implementation
{
    public class BaseDB : IBaseDB
    {                
        private IDbConnection _connection = null;
        private IDbTransaction _transaction = null;
        private Microsoft.Practices.EnterpriseLibrary.Data.Database _database = null;
        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
            }
        }
        public IDbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
            set
            {
                _transaction = value;
            }
        }
        public Microsoft.Practices.EnterpriseLibrary.Data.Database DatabaseProvider
        {
            get
            {
                return _database;
            }
            set
            {
                _database = value;
            }
        }
    }    
}
