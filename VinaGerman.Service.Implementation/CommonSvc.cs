using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Business;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Wcf.Security;

namespace VinaGerman.Service.Implementation
{
    [PersonnelInspectorBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CommonSvc : ICommonSvc
    {
        public bool Ping()
        {
            return true;
        }

        public UserProfileEntity GetUserProfile(string sUserName, string sPassword)
        {
            return Factory.Resolve<IUserBL>().GetUserProfile(sUserName, sPassword);
        }

        public void Dispose()
        {
            
        }
    }
}
