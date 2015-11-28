using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VinaGerman.DesktopApplication.ViewModels
{
    public class BaseMessage
    {
        #region properties
        public string Token { get; set; }
        public string Sender { get; set; }
        public List<string> Receivers { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        #endregion

        public BaseMessage()
        {
            Token = "";
            Sender = "";
            Receivers = new List<string>();
            Parameters = new Dictionary<string, object>();
        }
    }
}
