using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.ReportEntity
{
    public class HeaderReportEntity : BaseEntity
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string OfficialNoteCode { get; set; }

        [DataMember]
        public string OfficialNoteDescription { get; set; }
    }
}
