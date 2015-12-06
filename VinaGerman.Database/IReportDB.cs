using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;

namespace VinaGerman.Database
{
    public interface IReportDB
    {
        OfficialNoteEntity GetOfficialNoteByReportName(string reportName);
    }
}
