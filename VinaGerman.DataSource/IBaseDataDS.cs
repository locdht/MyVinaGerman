using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.DataSource
{

    public interface IBaseDataDS
    {
        #region Category
        List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject);
        CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject);
        bool DeleteCategory(CategoryEntity entityObject);
        #endregion

        #region Business
        List<BusinessEntity> SearchBusiness(BusinessSearchEntity searchObject);
        BusinessEntity AddOrUpdateBusiness(BusinessEntity entityObject);
        bool DeleteBusiness(BusinessEntity entityObject);
        #endregion

        #region Industry
        List<IndustryEntity> SearchIndustry(IndustrySearchEntity searchObject);
        IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject);
        bool DeleteIndustry(IndustryEntity entityObject);
        #endregion

        #region Article
        List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject);
        ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject);
        bool DeleteArticle(ArticleEntity entityObject);
        List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject);
        ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject);
        bool DeleteArticleRelation(ArticleRelationEntity entityObject);
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
        #endregion

        #region Order
        List<OrderEntity> SearchOrder(OrderSearchEntity searchObject);
        OrderEntity AddOrUpdateOrder(OrderEntity entityObject);
        bool DeleteOrder(OrderEntity entityObject);
        List<OrderlineEntity> GetOrderlinesForOrder(OrderEntity searchObject);
        OrderlineEntity AddOrUpdateOrderline(OrderlineEntity entityObject);
        bool DeleteOrderline(OrderlineEntity entityObject);
        List<LoanEntity> GetLoansForOrderline(OrderlineEntity searchObject);
        LoanEntity AddOrUpdateLoan(LoanEntity entityObject);
        bool DeleteLoan(LoanEntity entityObject);
        #endregion
    
    }
}
