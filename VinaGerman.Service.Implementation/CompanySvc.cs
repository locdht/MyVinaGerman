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
        #region Company
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
        #endregion

        #region Department
        public List<VinaGerman.Entity.BusinessEntity.DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject)
        {
            return Factory.Resolve<IDepartmentBL>().SearchDepartment(searchObject);
        }

        public VinaGerman.Entity.BusinessEntity.DepartmentEntity AddOrUpdateDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject)
        {
            return Factory.Resolve<IDepartmentBL>().AddOrUpdateDepartment(entityObject);
        }

        public bool DeleteDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject)
        {
            return Factory.Resolve<IDepartmentBL>().DeleteDepartment(entityObject);
        }
        #endregion

        #region Location
        public List<VinaGerman.Entity.BusinessEntity.LocationEntity> SearchLocation(LocationSearchEntity searchObject)
        {
            return Factory.Resolve<ILocationBL>().SearchLocation(searchObject);
        }

        public VinaGerman.Entity.BusinessEntity.LocationEntity AddOrUpdateLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            return Factory.Resolve<ILocationBL>().AddOrUpdateLocation(entityObject);
        }

        public bool DeleteLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            return Factory.Resolve<ILocationBL>().DeleteLocation(entityObject);
        }
        #endregion

        #region Contact
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject)
        {
            return Factory.Resolve<IContactBL>().SearchContact(searchObject);
        }

        public VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            return Factory.Resolve<IContactBL>().AddOrUpdateContact(entityObject);
        }

        public bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            return Factory.Resolve<IContactBL>().DeleteContact(entityObject);
        }
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity Object)
        {
            return Factory.Resolve<IContactBL>().GetContactForCompany(Object);
        }
        #endregion

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
