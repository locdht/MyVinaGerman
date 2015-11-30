using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business
{
    public interface IIndustryBL
    {
        List<IndustryEntity> SearchIndustry(IndustrySearchEntity searchObject);
        IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject);
        bool DeleteIndustry(IndustryEntity entityObject);
    }
}
