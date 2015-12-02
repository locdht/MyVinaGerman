using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Service
{
    [ServiceContract]
    public interface IBaseDataSvc : IDisposable
    {
        #region Category
        [OperationContract]
        List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject);
        [OperationContract]
        CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject);
        [OperationContract]
        bool DeleteCategory(CategoryEntity entityObject);
        #endregion

        #region Business
        [OperationContract]
        List<BusinessEntity> SearchBusiness(BusinessSearchEntity searchObject);
        [OperationContract]
        BusinessEntity AddOrUpdateBusiness(BusinessEntity entityObject);
        [OperationContract]
        bool DeleteBusiness(BusinessEntity entityObject);
        #endregion

        #region Industry
        [OperationContract]
        List<IndustryEntity> SearchIndustry(IndustrySearchEntity searchObject);
        [OperationContract]
        IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject);
        [OperationContract]
        bool DeleteIndustry(IndustryEntity entityObject);
        #endregion

        #region Article
        [OperationContract]
        List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject);
        [OperationContract]
        ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject);
        [OperationContract]
        bool DeleteArticle(ArticleEntity entityObject);
        #endregion

        #region Department
        [OperationContract]
        List<DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject);
        [OperationContract]
        DepartmentEntity AddOrUpdateDepartment(DepartmentEntity entityObject);
        [OperationContract]
        bool DeleteDepartment(DepartmentEntity entityObject);
        #endregion

        #region Location
        [OperationContract]
        List<LocationEntity> SearchLocation(LocationSearchEntity searchObject);
        [OperationContract]
        LocationEntity AddOrUpdateLocation(LocationEntity entityObject);
        [OperationContract]
        bool DeleteLocation(LocationEntity entityObject);
        #endregion
    }
}
