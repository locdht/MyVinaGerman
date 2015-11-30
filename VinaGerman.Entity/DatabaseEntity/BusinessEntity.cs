using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.DatabaseEntity
{
    [DataContract]
    public class BusinessEntity : VinaGerman.Entity.BaseEntity
    {        
        [DataMember]
        public int BusinessId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Deleted { get; set; }
    }
}
