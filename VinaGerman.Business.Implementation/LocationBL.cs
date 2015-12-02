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
    public class LocationBL : BaseBL, ILocationBL
    {
        public List<LocationEntity> SearchLocation(LocationSearchEntity searchObject)
        {
            return Factory.Resolve<ILocationDB>().SearchLocation(searchObject);
        }
        public LocationEntity AddOrUpdateLocation(LocationEntity entityObject)
        {
            return Factory.Resolve<ILocationDB>().AddOrUpdateLocation(entityObject);
        }
        public bool DeleteLocation(LocationEntity entityObject)
        {
            return Factory.Resolve<ILocationDB>().DeleteLocation(entityObject);
        }
    }
}
