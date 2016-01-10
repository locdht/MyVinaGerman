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
    public class CategoryBL : BaseBL, ICategoryBL
    {
        public List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ICategoryDB>().SearchCategories(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }            
        }
        public CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ICategoryDB>().AddOrUpdateCategory(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }            
        }
        public bool DeleteCategory(CategoryEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ICategoryDB>().DeleteCategory(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }              
        }
    }
}
