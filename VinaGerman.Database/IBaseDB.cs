using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Database
{
    public interface IBaseDB
    {
        IDbConnection Connection { get; set; }
        IDbTransaction Transaction { get; set; }
        Microsoft.Practices.EnterpriseLibrary.Data.Database DatabaseProvider { get; set; }
    }
}
