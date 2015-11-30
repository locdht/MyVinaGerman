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
            return Factory.Resolve<ICategoryDB>().SearchCategories(searchObject);
        }
        public CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject)
        {
            return Factory.Resolve<ICategoryDB>().AddOrUpdateCategory(entityObject);
        }
        public bool DeleteCategory(CategoryEntity entityObject)
        {
            return Factory.Resolve<ICategoryDB>().DeleteCategory(entityObject);
        }
    }
}
