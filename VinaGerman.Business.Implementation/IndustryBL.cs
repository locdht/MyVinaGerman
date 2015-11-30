using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Business.Implementation;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class IndustryBL : BaseBL, IIndustryBL
    {
        public List<IndustryEntity> SearchIndustry(IndustrySearchEntity searchObject)
        {
            return Factory.Resolve<IIndustryDB>().SearchIndustry(searchObject);
        }
        public IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject)
        {
            return Factory.Resolve<IIndustryDB>().AddOrUpdateIndustry(entityObject);
        }
        public bool DeleteIndustry(IndustryEntity entityObject)
        {
            return Factory.Resolve<IIndustryDB>().DeleteIndustry(entityObject);
        }
    }
}
