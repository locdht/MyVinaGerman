using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class CompanyBL : BaseBL, ICompanyBL
    {
        public List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject)
        {
            return Factory.Resolve<ICompanyDB>().SearchCompanies(searchObject);
        }
        public CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject)
        {
            return Factory.Resolve<ICompanyDB>().AddOrUpdateCompany(entityObject);
        }
        public bool DeleteCompany(CompanyEntity entityObject)
        {
            return Factory.Resolve<ICompanyDB>().DeleteCompany(entityObject);
        }
    }
}
