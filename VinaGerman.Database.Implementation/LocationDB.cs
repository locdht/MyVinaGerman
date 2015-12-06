using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.DatabaseEntity;
using VinaGerman.Entity.SearchEntity;
using Dapper;
namespace VinaGerman.Database.Implementation
{
    public class LocationDB : BaseDB, ILocationDB
    {
        public LocationEntity GetLocationById(int locationId)
        {
            LocationEntity result = null;
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Location.LocationId," + Environment.NewLine +
                "Location.Address," + Environment.NewLine +
                "Location.Description," + Environment.NewLine +
                "Location.CompanyId," + Environment.NewLine +
                "Location.Deleted" + Environment.NewLine +
                "FROM Location " + Environment.NewLine +
                "WHERE LocationId=@LocationId " + Environment.NewLine;
        
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<LocationEntity>(sqlStatement, new { LocationId = locationId }).FirstOrDefault();
            }
            return result;
        }
        public List<LocationEntity> SearchLocation(LocationSearchEntity searchObject)
        {
            List<LocationEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Location.LocationId," + Environment.NewLine +
                "Location.Address," + Environment.NewLine +
                "Location.Description," + Environment.NewLine +
                "Location.CompanyId," + Environment.NewLine +
                "Location.Deleted" + Environment.NewLine +
                "FROM Location " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (Description LIKE N'%" + searchObject.SearchText + "%' OR Address LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<LocationEntity>(sqlStatement).ToList();
            }
            return result;
        }

        public LocationEntity AddOrUpdateLocation(LocationEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.LocationId > 0)
            {
                sqlStatement += "UPDATE Location SET  " + Environment.NewLine +
                "Address=@Address," + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "CompanyId=@CompanyId," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE LocationId=@LocationId " + Environment.NewLine +
                "SELECT @LocationId AS LocationId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Location(  " + Environment.NewLine +
                "Address," + Environment.NewLine +
                "Description," + Environment.NewLine +
                "CompanyId," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@Address," + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@CompanyId," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS LocationId" + Environment.NewLine;
            }

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                entityObject.LocationId = conn.ExecuteScalar<int>(sqlStatement, new
                {
                    LocationId = entityObject.LocationId,
                    Phone = entityObject.Address,
                    Description = entityObject.Description,
                    CompanyId = entityObject.CompanyId,
                    Deleted = (entityObject.Deleted ? 1 : 0)
                });
            }
            return entityObject;
        }
        public bool DeleteLocation(LocationEntity entityObject)
        {
            string sqlStatement = "UPDATE Location SET Deleted=1 WHERE LocationId=@LocationId  " + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                conn.Execute(sqlStatement, new { LocationId = entityObject.LocationId });
            }
            return true;
        }
    }
}
