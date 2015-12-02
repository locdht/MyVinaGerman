using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.BusinessEntity
{
    public class ArticleRelationEntity : VinaGerman.Entity.BaseEntity
    {
        [DataMember]
        public int ArticleRelationId { get; set; }

        [DataMember]
        public int ArticleId { get; set; }

        [DataMember]
        public int RelatedArticleId { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string ArticleNo { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Unit { get; set; }

        [DataMember]
        public bool Deleted { get; set; }
    }
}
