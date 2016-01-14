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
    public class CategoryDB : BaseDB, ICategoryDB
    {
        public List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject)
        {
            List<CategoryEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Category.CategoryId," + Environment.NewLine +
                "Category.Description," + Environment.NewLine +
                "Category.Deleted" + Environment.NewLine +
                "FROM Category " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (Description LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            result = Connection.Query<CategoryEntity>(sqlStatement, null, Transaction).ToList();
            return result;
        }

        public CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.CategoryId > 0)
            {
                sqlStatement += "UPDATE Category SET  " + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE CategoryId=@CategoryId " + Environment.NewLine +
                "SELECT @CategoryId AS CategoryId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Category(  " + Environment.NewLine +
                "Description," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS CategoryId" + Environment.NewLine;
            }

            //execute
            entityObject.CategoryId = Connection.ExecuteScalar<int>(sqlStatement, new
            {
                CategoryId = entityObject.CategoryId,
                Description = entityObject.Description,
                Deleted = (entityObject.Deleted ? 1 : 0)
            }, Transaction);
            return entityObject;
        }
        public bool DeleteCategory(CategoryEntity entityObject)
        {
            string sqlStatement = "UPDATE Category SET Deleted=1 WHERE CategoryId=@CategoryId  " + Environment.NewLine;

            //execute
            Connection.Execute(sqlStatement, new { CategoryId = entityObject.CategoryId }, Transaction);
            return true;
        }
    }
}
