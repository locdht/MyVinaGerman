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
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IArticleDB>().SearchArticle(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }            
        }
        public ArticleEntity GetArticleByID(int ID)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IArticleDB>().GetArticleByID(ID);
                }
                finally
                {
                    db.CloseConnection();
                }
            }               
        }
        public ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IArticleDB>().AddOrUpdateArticle(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public bool DeleteArticle(ArticleEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IArticleDB>().DeleteArticle(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public List<ArticleRelationEntity> GetArticleRelationsForArticle(ArticleEntity searchObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IArticleDB>().GetArticleRelationsForArticle(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }  
        }
        public ArticleRelationEntity AddOrUpdateArticleRelation(ArticleRelationEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IArticleDB>().AddOrUpdateArticleRelation(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public bool DeleteArticleRelation(ArticleRelationEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IArticleDB>().DeleteArticleRelation(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }              
        }
    }
}
