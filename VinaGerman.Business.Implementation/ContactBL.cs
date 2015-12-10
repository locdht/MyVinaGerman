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
            return Factory.Resolve<IContactDB>().SearchContact(searchObject);
        }
        public VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            return Factory.Resolve<IContactDB>().AddOrUpdateContact(entityObject);
        }
        public bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            return Factory.Resolve<IContactDB>().DeleteContact(entityObject);
        }

        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity Object)
        {
            return Factory.Resolve<IContactDB>().GetContactForCompany(Object);
        }
    }
}
