using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Business;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Wcf.Security;
using VinaGerman.Wcf.Security.Server;

namespace VinaGerman.Service.Implementation
{
    [PersonnelInspectorBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CompanySvc : ICompanySvc
    {
        public List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject)
        {   
            return Factory.Resolve<ICompanyBL>().SearchCompanies(searchObject);
        }

        public CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject)
        {
            return Factory.Resolve<ICompanyBL>().AddOrUpdateCompany(entityObject);
        }

        public bool DeleteCompany(CompanyEntity entityObject)
        {
            return Factory.Resolve<ICompanyBL>().DeleteCompany(entityObject);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
