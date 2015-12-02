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
    
    }
}
