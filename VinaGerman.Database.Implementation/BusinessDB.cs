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
    public class BusinessDB : BaseDB, IBusinessDB
    {
        public List<BusinessEntity> SearchBusiness(BusinessSearchEntity searchObject)
        {
            List<BusinessEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Business.BusinessId," + Environment.NewLine +
                "Business.Description," + Environment.NewLine +
                "Business.Deleted" + Environment.NewLine +
                "FROM Business " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (Description LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            result = Connection.Query<BusinessEntity>(sqlStatement).ToList();
            return result;
        }

        public BusinessEntity AddOrUpdateBusiness(BusinessEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.BusinessId > 0)
            {
                sqlStatement += "UPDATE Business SET  " + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE BusinessId=@BusinessId " + Environment.NewLine +
                "SELECT @BusinessId AS BusinessId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Business(  " + Environment.NewLine +
                "Description," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS BusinessId" + Environment.NewLine;
            }

            //execute
            entityObject.BusinessId = Connection.ExecuteScalar<int>(sqlStatement, new
            {
                BusinessId = entityObject.BusinessId,
                Description = entityObject.Description,
                Deleted = (entityObject.Deleted ? 1 : 0)
            });
            return entityObject;
        }
        public bool DeleteBusiness(BusinessEntity entityObject)
        {
            string sqlStatement = "UPDATE Business SET Deleted=1 WHERE BusinessId=@BusinessId  " + Environment.NewLine;

            //execute
            Connection.Execute(sqlStatement, new { BusinessId = entityObject.BusinessId });
            return true;
        }
    }
}
