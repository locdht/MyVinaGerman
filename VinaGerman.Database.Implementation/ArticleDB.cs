using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using Dapper;
namespace VinaGerman.Database.Implementation
{
    public class ArticleDB : BaseDB, IArticleDB
    {
        public List<ArticleEntity> SearchArticle(ArticleSearchEntity searchObject)
        {
            List<ArticleEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Article.ArticleId," + Environment.NewLine +
                "Article.ArticleNo," + Environment.NewLine +
                "Article.Description," + Environment.NewLine +
                "Article.Unit," + Environment.NewLine +
                "Article.Deleted" + Environment.NewLine +
                "FROM Article " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (ArticleNo LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<ArticleEntity>(sqlStatement).ToList();
            }
            return result;
        }

        public ArticleEntity AddOrUpdateArticle(ArticleEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.ArticleId > 0)
            {
                sqlStatement += "UPDATE Article SET  " + Environment.NewLine +
                "ArticleNo=@ArticleNo," + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "Unit=@Unit," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE ArticleId=@ArticleId " + Environment.NewLine +
                "SELECT @ArticleId AS ArticleId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Article(  " + Environment.NewLine +
                "ArticleNo," + Environment.NewLine +
                "Description," + Environment.NewLine +
                "Unit," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@ArticleNo," + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@Unit," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS ArticleId" + Environment.NewLine;
            }

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                entityObject.ArticleId = conn.ExecuteScalar<int>(sqlStatement, new
                {
                    ArticleId = entityObject.ArticleId,
                    ArticleNo = entityObject.ArticleNo,
                    Description = entityObject.Description,
                    Unit = entityObject.Unit,
                    Deleted = (entityObject.Deleted ? 1 : 0)
                });
            }
            return entityObject;
        }
        public bool DeleteArticle(ArticleEntity entityObject)
        {
            string sqlStatement = "UPDATE Article SET Deleted=1 WHERE ArticleId=@ArticleId  " + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                conn.Execute(sqlStatement, new { ArticleId = entityObject.ArticleId });
            }
            return true;
        }
    }
}
