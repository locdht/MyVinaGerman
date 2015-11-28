using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business
{
    public interface ICompanyBL
    {
        List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject);
        CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject);
        bool DeleteCompany(CompanyEntity entityObject);
    }
}
