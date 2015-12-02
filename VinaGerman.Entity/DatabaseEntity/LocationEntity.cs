﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.DatabaseEntity
{
    [DataContract]
    public class LocationEntity : VinaGerman.Entity.BaseEntity
    {        
        [DataMember]
        public int LocationId { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int CompanyId { get; set; }

        [DataMember]
        public bool Deleted { get; set; }
    }
}
