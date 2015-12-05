using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using VinaGerman.Service;

namespace VinaGerman.DataSource.Implementation
{
    public class BaseDataDS : BaseDS<IBaseDataSvc>, IBaseDataDS
    {
        protected override string CategoryName
        {
            get
            {
                return "BaseData.svc";
            }
        }

        #region Category
        public List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchCategories(searchObject);
            channel.Dispose();
            return result;
        }
        public CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateCategory(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteCategory(CategoryEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteCategory(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Business
        public List<BusinessEntity> SearchBusiness(BusinessSearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchBusiness(searchObject);
            channel.Dispose();
            return result;
        }
        public BusinessEntity AddOrUpdateBusiness(BusinessEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateBusiness(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteBusiness(BusinessEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteBusiness(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Industry
        public List<IndustryEntity> SearchIndustry(IndustrySearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchIndustry(searchObject);
            channel.Dispose();
            return result;
        }
        public IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateIndustry(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteIndustry(IndustryEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteIndustry(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion
        
        #region Article
        public List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchArticle(searchObject);
            channel.Dispose();
            return result;
        }
        public ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateArticle(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteArticle(ArticleEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteArticle(entityObject);
            channel.Dispose();
            return result;
        }
        public List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.GetArticleRelationsForArticle(searchObject);
            channel.Dispose();
            return result;
        }
        public ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateArticleRelation(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteArticleRelation(ArticleRelationEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteArticleRelation(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Department
        public List<VinaGerman.Entity.BusinessEntity.DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchDepartment(searchObject);
            channel.Dispose();
            return result;
        }
        public VinaGerman.Entity.BusinessEntity.DepartmentEntity AddOrUpdateDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateDepartment(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteDepartment(VinaGerman.Entity.BusinessEntity.DepartmentEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteDepartment(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Location
        public List<VinaGerman.Entity.BusinessEntity.LocationEntity> SearchLocation(LocationSearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchLocation(searchObject);
            channel.Dispose();
            return result;
        }
        public VinaGerman.Entity.BusinessEntity.LocationEntity AddOrUpdateLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateLocation(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteLocation(VinaGerman.Entity.BusinessEntity.LocationEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteLocation(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Contact
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchContact(searchObject);
            channel.Dispose();
            return result;
        }
        public VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateContact(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteContact(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion

        #region Order
        public List<OrderEntity> SearchOrder(OrderSearchEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.SearchOrder(searchObject);
            channel.Dispose();
            return result;
        }
        public OrderEntity AddOrUpdateOrder(OrderEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateOrder(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteOrder(OrderEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteOrder(entityObject);
            channel.Dispose();
            return result;
        }
        public List<OrderlineEntity> GetOrderRelationsForOrder(OrderEntity searchObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.GetOrderRelationsForOrder(searchObject);
            channel.Dispose();
            return result;
        }
        public OrderlineEntity AddOrUpdateOrderRelation(OrderlineEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.AddOrUpdateOrderRelation(entityObject);
            channel.Dispose();
            return result;
        }
        public bool DeleteOrderRelation(OrderlineEntity entityObject)
        {
            IBaseDataSvc channel = CreateChannel();
            var result = channel.DeleteOrderRelation(entityObject);
            channel.Dispose();
            return result;
        }
        #endregion
    }
}
