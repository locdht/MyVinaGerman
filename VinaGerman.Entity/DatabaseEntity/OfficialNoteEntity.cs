using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.DatabaseEntity
{
    public class OfficialNoteEntity : BaseEntity
    {
        [DataMember]
        public int OfficialNoteId { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
