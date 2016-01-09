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
        #region company
        [OperationContract]
        List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject);
        [OperationContract]
        CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject);
        [OperationContract]
        bool DeleteCompany(CompanyEntity entityObject);
        #endregion

        #region Department
        [OperationContract]
        List<VinaGerman.Entity.BusinessEntity.DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject);
        [OperationContract]
        VinaGerman.Entity.BusinessEntity.DepartmentEntity AddOrUpdateDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject);
        [OperationContract]
        bool DeleteDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject);
        #endregion

        #region Location
        [OperationContract]
        List<VinaGerman.Entity.BusinessEntity.LocationEntity> SearchLocation(LocationSearchEntity searchObject);
        [OperationContract]
        VinaGerman.Entity.BusinessEntity.LocationEntity AddOrUpdateLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject);
        [OperationContract]
        bool DeleteLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject);
        #endregion

        #region Contact
        [OperationContract]
        List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject);
        [OperationContract]
        VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject);
        [OperationContract]
        bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject);
        [OperationContract]
        List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity hObject);
        #endregion
    }
}
