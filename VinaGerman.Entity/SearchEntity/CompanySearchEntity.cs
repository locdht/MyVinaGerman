using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.SearchEntity
{
    public class CompanySearchEntity : BaseEntity
    {
        [DataMember]
        public string SearchText { get; set; }

        [DataMember]
        public bool IsSupplier { get; set; }

        [DataMember]
        public bool IsCustomer { get; set; }

        [DataMember]
        public int NotIncludedCompany { get; set; }
    }
}
