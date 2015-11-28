using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.DatabaseEntity
{
    [DataContract]
    public class CompanyEntity : VinaGerman.Entity.BaseEntity
    {        
        [DataMember]
        public int CompanyId { get; set; }

        [DataMember]
        public int CompanyOwner { get; set; }

        [DataMember]
        public string CompanyCode { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string TaxCode { get; set; }

        [DataMember]
        public string Website { get; set; }

        [DataMember]
        public bool IsSupplier { get; set; }

        [DataMember]
        public bool IsCustomer { get; set; }

        [DataMember]
        public bool Deleted { get; set; }
    }
}
