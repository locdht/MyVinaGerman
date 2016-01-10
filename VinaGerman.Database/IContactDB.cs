using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;

namespace VinaGerman.Database
{
    public interface IContactDB : IBaseDB
    {
        List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject);
        VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject);
        bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject);

        List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity hObject);
    }
}
