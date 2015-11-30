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
    public class BusinessBL : BaseBL, IBusinessBL
    {
        public List<BusinessEntity> SearchBusiness(BusinessSearchEntity searchObject)
        {
            return Factory.Resolve<IBusinessDB>().SearchBusiness(searchObject);
        }
        public BusinessEntity AddOrUpdateBusiness(BusinessEntity entityObject)
        {
            return Factory.Resolve<IBusinessDB>().AddOrUpdateBusiness(entityObject);
        }
        public bool DeleteBusiness(BusinessEntity entityObject)
        {
            return Factory.Resolve<IBusinessDB>().DeleteBusiness(entityObject);
        }
    }
}
