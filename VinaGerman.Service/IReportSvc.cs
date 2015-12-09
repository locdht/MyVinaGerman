using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.ReportEntity;

namespace VinaGerman.Service
{
    [ServiceContract]
    public interface IReportSvc : IDisposable
    {
        [OperationContract]
        HeaderReportEntity GetHeaderReport(int companyId, int locationId, string reportName);
    }
}
