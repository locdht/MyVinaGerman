using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;
using Dapper;
namespace VinaGerman.Database.Implementation
{
    public class DepartmentDB : BaseDB, IDepartmentDB
    {
        public List<DepartmentEntity> SearchDepartment(DepartmentSearchEntity searchObject)
        {
            List<DepartmentEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Department.DepartmentId," + Environment.NewLine +
                "Department.Phone," + Environment.NewLine +
                "Department.Description," + Environment.NewLine +
                "Company.Description as CompanyName," + Environment.NewLine +
                "Department.CompanyId," + Environment.NewLine +
                "Department.Deleted" + Environment.NewLine +
                "FROM Department JOIN Company ON Department.CompanyId=Company.CompanyId " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (Description LIKE N'%" + searchObject.SearchText + "%' OR Phone LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<DepartmentEntity>(sqlStatement).ToList();
            }
            return result;
        }

        public DepartmentEntity AddOrUpdateDepartment(DepartmentEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.DepartmentId > 0)
            {
                sqlStatement += "UPDATE Department SET  " + Environment.NewLine +
                "Phone=@Phone," + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "CompanyId=@CompanyId," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE DepartmentId=@DepartmentId " + Environment.NewLine +
                "SELECT @DepartmentId AS DepartmentId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Department(  " + Environment.NewLine +
                "Phone," + Environment.NewLine +
                "Description," + Environment.NewLine +
                "CompanyId," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@Phone," + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@CompanyId," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS DepartmentId" + Environment.NewLine;
            }

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                entityObject.DepartmentId = conn.ExecuteScalar<int>(sqlStatement, new
                {
                    DepartmentId = entityObject.DepartmentId,
                    Phone = entityObject.Phone,
                    Description = entityObject.Description,
                    CompanyId = entityObject.CompanyId,
                    Deleted = (entityObject.Deleted ? 1 : 0)
                });
            }
            return entityObject;
        }
        public bool DeleteDepartment(DepartmentEntity entityObject)
        {
            string sqlStatement = "UPDATE Department SET Deleted=1 WHERE DepartmentId=@DepartmentId  " + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                conn.Execute(sqlStatement, new { DepartmentId = entityObject.DepartmentId });
            }
            return true;
        }
    }
}
