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
        ArticleEntity GetArticleByID(int ID);
        ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject);
        bool DeleteArticle(ArticleEntity entityObject);
        List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject);
        ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject);
        bool DeleteArticleRelation(ArticleRelationEntity entityObject);
        #endregion                  
    }
}
