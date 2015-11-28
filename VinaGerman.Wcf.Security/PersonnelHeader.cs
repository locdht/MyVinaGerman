using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VinaGerman.Wcf.Security
{
    [DataContract]
    public class PersonnelHeader
    {
        [DataMember]
        public bool IsWindowAuthentication { get; set; }
        [DataMember]
        public string Database { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ServerUrl { get; set; }
        [DataMember]
        public string LanguageId { get; set; }
        [DataMember]
        public bool IsResolved { get; set; }
        [DataMember]
        public bool IsReset { get; set; }
    }
}
