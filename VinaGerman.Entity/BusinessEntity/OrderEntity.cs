using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.BusinessEntity
{
    [DataContract]
    public class OrderEntity : VinaGerman.Entity.BaseEntity
    {        
        [DataMember]
        public int OrderId { get; set; }

        [DataMember]
        public int OrderType { get; set; }

        [DataMember]
        public int BusinessId { get; set; }
        
        [DataMember]
        public int IndustryId { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int ResponsibleBy { get; set; }

        [DataMember]
        public DateTime OrderDate { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public int CustomerCompanyId { get; set; }

        [DataMember]
        public int CustomerContactId { get; set; }

        [DataMember]
        public string OrderNumber { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string ContactName { get; set; }
    }
}
