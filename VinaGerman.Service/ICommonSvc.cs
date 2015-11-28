using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;

namespace VinaGerman.Service
{
    [ServiceContract]
    public interface ICommonSvc : IDisposable
    {
        [OperationContract]
        bool Ping();

        [OperationContract]
        UserProfileEntity GetUserProfile(string sUserName, string sPassword);
    }
}
