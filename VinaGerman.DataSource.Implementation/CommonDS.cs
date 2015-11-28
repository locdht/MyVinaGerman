using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Service;

namespace VinaGerman.DataSource.Implementation
{
    public class CommonDS : BaseDS<ICommonSvc>, ICommonDS
    {
        protected override string CategoryName
        {
            get
            {
                return "Common.svc";
            }
        }
        public bool Ping()
        {
            ICommonSvc channel = CreateCommonChannel();
            var result = channel.Ping();
            channel.Dispose();
            return result;
        }
        public UserProfileEntity GetUserProfile(string sUserName, string sPassword)
        {
            ICommonSvc channel = CreateCommonChannel();
            var result = channel.GetUserProfile(sUserName, sPassword);
            channel.Dispose();
            return result;
        }
    }
}
