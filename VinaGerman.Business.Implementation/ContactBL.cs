using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Database;
using VinaGerman.Entity;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business.Implementation
{
    public class ContactBL : BaseBL, IContactBL
    {
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IContactDB>().SearchContact(searchObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }             
        }
        public VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IContactDB>().AddOrUpdateContact(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }               
        }
        public bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IContactDB>().DeleteContact(entityObject);
                }
                finally
                {
                    db.CloseConnection();
                }
            }                
        }

        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity Object)
        {
            //execute
            using (var db = VinaGerman.Database.VinagermanDatabase.GetDatabaseInstance())
            {
                try
                {
                    db.OpenConnection();
                    return db.Resolve<IContactDB>().GetContactForCompany(Object);
                }
                finally
                {
                    db.CloseConnection();
                }
            }              
        }
    }
}
