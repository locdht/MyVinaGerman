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
    public class ContactBL : BaseBL, IContactBL
    {
        public List<ContactEntity> SearchContact(ContactSearchEntity searchObject)
        {
            return Factory.Resolve<IContactDB>().SearchContact(searchObject);
        }
        public ContactEntity AddOrUpdateContact(ContactEntity entityObject)
        {
            return Factory.Resolve<IContactDB>().AddOrUpdateContact(entityObject);
        }
        public bool DeleteContact(ContactEntity entityObject)
        {
            return Factory.Resolve<IContactDB>().DeleteContact(entityObject);
        }
    }
}
