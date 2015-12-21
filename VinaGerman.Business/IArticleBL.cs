using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business
{
    public interface IArticleBL
    {
        List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject);
        ArticleEntity GetArticleByID(int ID);
        ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject);
        bool DeleteArticle(ArticleEntity entityObject);
        List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject);
        ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject);
        bool DeleteArticleRelation(ArticleRelationEntity entityObject);
    }
}
