using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Database
{
    public interface ICategoryDB : IBaseDB
    {
        List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject);
        CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject);
        bool DeleteCategory(CategoryEntity entityObject);
    }
}
