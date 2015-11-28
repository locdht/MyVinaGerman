using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Service
{
    [ServiceContract]
    public interface ICompanySvc : IDisposable
    {
        [OperationContract]
        List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject);
        [OperationContract]
        CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject);
        [OperationContract]
        bool DeleteCompany(CompanyEntity entityObject);
    }
}
