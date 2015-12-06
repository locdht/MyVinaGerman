using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using Dapper;
namespace VinaGerman.Database.Implementation
{
    public class ReportDB : BaseDB, IReportDB
    {
        public OfficialNoteEntity GetOfficialNoteByReportName(string reportName)
        {
            OfficialNoteEntity result = null;
            string sqlStatement = "SELECT  " + Environment.NewLine +
                "OfficialNote.OfficialNoteId," + Environment.NewLine +                
                "OfficialNote.Description," + Environment.NewLine +
                "OfficialNote.Code " + Environment.NewLine +
                "FROM OfficialNote JOIN Report ON Report.OfficialNoteId=OfficialNote.OfficialNoteId " + Environment.NewLine +
                "WHERE ReportName=@ReportName" + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<OfficialNoteEntity>(sqlStatement, new { ReportName = reportName }).FirstOrDefault();
            }
            return result;
        }
    }
}
