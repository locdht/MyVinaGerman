using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.ReportEntity;

namespace VinaGerman.Business
{
    public interface IReportBL
    {
        HeaderReportEntity GetHeaderReport(int companyId, int locationId, string reportName);
    }
}
