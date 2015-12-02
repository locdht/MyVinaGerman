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
    public interface ILocationBL
    {
        List<LocationEntity> SearchLocation(LocationSearchEntity searchObject);
        LocationEntity AddOrUpdateLocation(LocationEntity entityObject);
        bool DeleteLocation(LocationEntity entityObject);
    }
}
