﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.BusinessEntity
{
    public class LoanEntity : VinaGerman.Entity.BaseEntity
    {
        [DataMember]
        public int LoanId { get; set; }
        [DataMember]
        public int OrderlineId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public int RemainingQuantity { get; set; }

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

        public LoanEntity()
        {
            OrderlineId = -1;
            ArticleId = -1;
            CategoryId = -1;
            ArticleNo = "";
            Description = "";
            Quantity = 0;
        }
    }
}
