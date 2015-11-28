using PortableIoC;
using VinaGerman.Database;
using VinaGerman.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;

namespace VinaGerman.Business.Implementation
{
    public class UserBL : BaseBL, IUserBL
    {
        public UserBL() { }
       
        public bool Login(string sUserName, string sPassword)
        {
            return Factory.Resolve<IUserDB>().Login(sUserName, sPassword);
        }

        public UserProfileEntity GetUserProfile(string sUserName, string sPassword)
        {
            return Factory.Resolve<IUserDB>().GetUserProfile(sUserName, sPassword);
        }
    }
}
