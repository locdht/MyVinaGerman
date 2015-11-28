using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;

namespace VinaGerman.DataSource
{
    public interface ICommonDS
    {
        bool Ping();
        UserProfileEntity GetUserProfile(string sUserName, string sPassword);
    }
}
