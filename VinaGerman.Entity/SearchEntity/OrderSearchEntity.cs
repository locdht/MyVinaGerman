using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.SearchEntity
{
    public class OrderSearchEntity : BaseEntity
    {
        [DataMember]
        public string SearchText { get; set; }
    }
}
