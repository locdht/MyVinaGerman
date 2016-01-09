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

        #region Company
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
        #endregion

        #region Department
        public List<VinaGerman.Entity.BusinessEntity.DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.SearchDepartment(searchObject);
            channel.Dispose();
            return result;
        }
        public VinaGerman.Entity.BusinessEntity.DepartmentEntity AddOrUpdateDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.AddOrUpdateDepartment(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.DeleteDepartment(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Location
        public List<VinaGerman.Entity.BusinessEntity.LocationEntity> SearchLocation(LocationSearchEntity searchObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.SearchLocation(searchObject);
            channel.Dispose();
            return result;
        }
        public VinaGerman.Entity.BusinessEntity.LocationEntity AddOrUpdateLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.AddOrUpdateLocation(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.DeleteLocation(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Contact
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.SearchContact(searchObject);
            channel.Dispose();
            return result;
        }
        public VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.AddOrUpdateContact(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.DeleteContact(entityObject);
            channel.Dispose();
            return result;
        }

        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity Object)
        {
            ICompanySvc channel = CreateChannel();
            var result = channel.GetContactForCompany(Object);
            channel.Dispose();
            return result;
        }
        #endregion
    }
}
