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
    public class BaseDB
    {
        public static string CONNECTION_STRING = "DefaultConnection";
        protected Microsoft.Practices.EnterpriseLibrary.Data.Database GetDatabaseInstance()
        {
            // Configure the DatabaseFactory to read its configuration from the .config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            // Create a Database object from the factory using the connection string name.
            return factory.Create(CONNECTION_STRING);
        }
    }    
}
