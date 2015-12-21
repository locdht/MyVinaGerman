using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class ArticleBL : BaseBL, IArticleBL
    {
        public List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject)
        {
            return Factory.Resolve<IArticleDB>().SearchArticle(searchObject);
        }
        public ArticleEntity GetArticleByID(int ID)
        {
            return Factory.Resolve<IArticleDB>().GetArticleByID(ID);
        }
        public ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject)
        {
            return Factory.Resolve<IArticleDB>().AddOrUpdateArticle(entityObject);
        }
        public bool DeleteArticle(ArticleEntity entityObject)
        {
            return Factory.Resolve<IArticleDB>().DeleteArticle(entityObject);
        }
        public List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject)
        {
            return Factory.Resolve<IArticleDB>().GetArticleRelationsForArticle(searchObject);
        }
        public ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject)
        {
            return Factory.Resolve<IArticleDB>().AddOrUpdateArticleRelation(entityObject);
        }
        public bool DeleteArticleRelation(ArticleRelationEntity entityObject)
        {
            return Factory.Resolve<IArticleDB>().DeleteArticleRelation(entityObject);
        }
    }
}
