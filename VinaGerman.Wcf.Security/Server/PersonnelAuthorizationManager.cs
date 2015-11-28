using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace VinaGerman.Wcf.Security.Server
{
    public class PersonnelAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        { 
            //LocDHT: need this to avoid Evaluate exception
            operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = System.Threading.Thread.CurrentPrincipal;
            // If this point is reached, return false to deny access.
            return true;
        }
    }

}
