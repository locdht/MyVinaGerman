using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DataSource
{
    public interface ICompanyDS
    {
        #region company
        List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject);
        CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject);
        bool DeleteCompany(CompanyEntity entityObject);
        #endregion

        #region Department
        List<VinaGerman.Entity.BusinessEntity.DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject);
        VinaGerman.Entity.BusinessEntity.DepartmentEntity AddOrUpdateDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject);
        bool DeleteDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject);
        #endregion

        #region Location
        List<VinaGerman.Entity.BusinessEntity.LocationEntity> SearchLocation(LocationSearchEntity searchObject);
        VinaGerman.Entity.BusinessEntity.LocationEntity AddOrUpdateLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject);
        bool DeleteLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject);
        #endregion

        #region Contact
        List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject);
        VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject);
        bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject);
        List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity Object);
        #endregion
    }
}
