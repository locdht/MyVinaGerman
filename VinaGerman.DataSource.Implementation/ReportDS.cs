using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.ReportEntity;
using VinaGerman.Service;

namespace VinaGerman.DataSource.Implementation
{
    public class ReportDS : BaseDS<IReportSvc>, IReportDS
    {
        protected override string CategoryName
        {
            get
            {
                return "Company.svc";
            }
        }
      
        public HeaderReportEntity GetHeaderReport(int companyId, int locationId, string reportName)
        {
            IReportSvc channel = CreateChannel();
            var result = channel.GetHeaderReport(companyId, locationId, reportName);
            channel.Dispose();
            return result;
        }
    }
}
