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
        [OperationContract]
        List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject);
        [OperationContract]
        ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject);
        [OperationContract]
        bool DeleteArticleRelation(ArticleRelationEntity entityObject);
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
        #endregion

        #region Order
        [OperationContract]
        List<OrderEntity> SearchOrder(OrderSearchEntity searchObject);
        [OperationContract]
        OrderEntity AddOrUpdateOrder(OrderEntity entityObject);
        [OperationContract]
        bool DeleteOrder(OrderEntity entityObject);
        [OperationContract]
        List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject);
        [OperationContract]
        OrderlineEntity AddOrUpdateOrderline(OrderlineEntity entityObject);
        [OperationContract]
        bool DeleteOrderline(OrderlineEntity entityObject);
        [OperationContract]
        List<LoanEntity> GetLoansForOrderline(OrderlineEntity searchObject);
        [OperationContract]
        LoanEntity AddOrUpdateLoan(LoanEntity entityObject);
        [OperationContract]
        bool DeleteLoan(LoanEntity entityObject);
        #endregion
    
    }
}
