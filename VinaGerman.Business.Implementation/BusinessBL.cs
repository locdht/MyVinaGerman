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
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IBusinessDB>().SearchBusiness(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public BusinessEntity AddOrUpdateBusiness(BusinessEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IBusinessDB>().AddOrUpdateBusiness(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }              
        }
        public bool DeleteBusiness(BusinessEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IBusinessDB>().DeleteBusiness(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }              
        }        
    }
}
