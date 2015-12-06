﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Database
{
    public interface ILocationDB
    {
        LocationEntity GetLocationById(int locationId);
        List<LocationEntity> SearchLocation(LocationSearchEntity searchObject);
        LocationEntity AddOrUpdateLocation(LocationEntity entityObject);
        bool DeleteLocation(LocationEntity entityObject);
    }
}
