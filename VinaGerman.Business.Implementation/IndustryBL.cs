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
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IIndustryDB>().SearchIndustry(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public IndustryEntity AddOrUpdateIndustry(IndustryEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IIndustryDB>().AddOrUpdateIndustry(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }               
        }
        public bool DeleteIndustry(IndustryEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IIndustryDB>().DeleteIndustry(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }
    }
}
