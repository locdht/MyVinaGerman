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
    public interface ICategoryBL
    {
        List<CategoryEntity> SearchCategories(CategorySearchEntity searchObject);
        CategoryEntity AddOrUpdateCategory(CategoryEntity entityObject);
        bool DeleteCategory(CategoryEntity entityObject);
    }
}
