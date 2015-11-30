﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.DatabaseEntity
{
    [DataContract]
    public class IndustryEntity : VinaGerman.Entity.BaseEntity
    {        
        [DataMember]
        public int IndustryId { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Deleted { get; set; }
    }
}
