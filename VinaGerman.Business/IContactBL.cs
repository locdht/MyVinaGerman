using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Business
{
    public interface IContactBL
    {
        List<ContactEntity> SearchContact(ContactSearchEntity searchObject);
        ContactEntity AddOrUpdateContact(ContactEntity entityObject);
        bool DeleteContact(ContactEntity entityObject);
    }
}
