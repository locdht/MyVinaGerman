using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace VinaGerman.Wcf.Security.Server
{
    public static class ServerPersonnelHeaderContext
    {
        static ServerPersonnelHeaderContext() { }

        public static PersonnelHeader HeaderInformation
        {
            get
            {
                var prop = OperationContext.Current.IncomingMessageProperties["PersonnelHeader"];
                if (prop != null && prop.GetType() == typeof(PersonnelHeader))
                {
                    PersonnelHeader header = (PersonnelHeader)prop;
                    return header;
                }
                else
                {
                    throw new Exception("PersonnelHeader is not available");
                }
            }
        }       
    }
}
