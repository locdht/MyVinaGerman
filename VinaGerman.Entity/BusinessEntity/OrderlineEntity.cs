using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.BusinessEntity
{
    [DataContract]
    public class OrderlineEntity : VinaGerman.Entity.BaseEntity
    {
        [DataMember]
        public int OrderlineId { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public float Commission { get; set; }
        [DataMember]
        public int RemainingQuantity { get; set; }
        [DataMember]
        public DateTime PayDate { get; set; }
        [DataMember]
        public DateTime PaidDate { get; set; }

        [DataMember]
        public int ArticleId { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string ArticleNo { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public bool Deleted { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int ModifiedBy { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
