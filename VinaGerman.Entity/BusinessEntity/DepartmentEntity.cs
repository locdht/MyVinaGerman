using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.BusinessEntity
{
    [DataContract]
    public class DepartmentEntity : VinaGerman.Entity.BaseEntity
    {        
        [DataMember]
        public int DepartmentId { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int CompanyId { get; set; }

        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public bool Deleted { get; set; }
    }
}
