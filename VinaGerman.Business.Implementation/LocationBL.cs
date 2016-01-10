using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class LocationBL : BaseBL, ILocationBL
    {
        public List<LocationEntity> SearchLocation(LocationSearchEntity searchObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ILocationDB>().SearchLocation(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }            
        }
        public LocationEntity AddOrUpdateLocation(LocationEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ILocationDB>().AddOrUpdateLocation(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }               
        }
        public bool DeleteLocation(LocationEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<ILocationDB>().DeleteLocation(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
    }
}
