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
    }
}
