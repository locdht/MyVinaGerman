using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;

namespace VinaGerman.Business
{
    public interface IUserBL
    {
        bool Login(string sUserName, string sPassword);
        UserProfileEntity GetUserProfile(string sUserName, string sPassword);
    }
}
