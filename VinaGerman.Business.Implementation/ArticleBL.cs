using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
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
        public ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject)
        {
            return Factory.Resolve<IArticleDB>().AddOrUpdateArticle(entityObject);
        }
        public bool DeleteArticle(ArticleEntity entityObject)
        {
            return Factory.Resolve<IArticleDB>().DeleteArticle(entityObject);
        }
    }
}
