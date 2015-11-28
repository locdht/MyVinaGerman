using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Service;

namespace VinaGerman.DataSource.Implementation
{
    public class CompanyDS : BaseDS<ICompanySvc>, ICompanyDS
    {
        protected override string CategoryName
        {
            get
            {
                return "Company.svc";
            }
        }
        public List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.SearchCompanies(searchObject);
            channel.Dispose();
            return result;
        }
        public CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.AddOrUpdateCompany(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteCompany(CompanyEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.DeleteCompany(entityObject);
            channel.Dispose();
            return result;
        }
    }
}
