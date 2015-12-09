using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Business;
using VinaGerman.Entity;
using VinaGerman.Entity.ReportEntity;
using VinaGerman.Wcf.Security;

namespace VinaGerman.Service.Implementation
{
    [PersonnelInspectorBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ReportSvc : IReportSvc
    {
        public HeaderReportEntity GetHeaderReport(int companyId, int locationId, string reportName)
        {
            return Factory.Resolve<IReportBL>().GetHeaderReport(companyId, locationId, reportName);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
