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
    public class CompanyDB : BaseDB, ICompanyDB
    {
        public List<CompanyEntity> SearchCompanies(CompanySearchEntity searchObject)
        {
            List<CompanyEntity> result = null;            
            string sqlStatement = "SELECT TOP 100  " + Environment.NewLine +
                "Company.CompanyId," + Environment.NewLine +
                "Company.CompanyOwner," + Environment.NewLine +
                "Company.Description," + Environment.NewLine +
                "Company.Deleted," + Environment.NewLine +
                "Company.Address," + Environment.NewLine +
                "Company.CompanyCode," + Environment.NewLine +
                "Company.TaxCode," + Environment.NewLine +
                "Company.Website," + Environment.NewLine +
                "Company.Phone," + Environment.NewLine +
                "Company.IsSupplier," + Environment.NewLine +
                "Company.IsCustomer" + Environment.NewLine +
                "FROM Company " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;

            if (searchObject.IsCustomer)
            {
                sqlStatement += "AND IsCustomer=" + (searchObject.IsCustomer ? 1 : 0) + Environment.NewLine;
            }

            if (searchObject.IsSupplier)
            {
                sqlStatement += "AND IsSupplier=" + (searchObject.IsSupplier ? 1 : 0) + Environment.NewLine;
            }

            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (Description LIKE N'%" + searchObject.SearchText + "%' OR TaxCode LIKE N'%" + searchObject.SearchText + "%' OR Phone LIKE N'%" + searchObject.SearchText + "%' OR CompanyCode LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }

            if (searchObject.NotIncludedCompany > 0)
            {
                sqlStatement += "AND CompanyId <>" + searchObject.NotIncludedCompany + Environment.NewLine;
            }

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<CompanyEntity>(sqlStatement).ToList();
            }
            return result;
        }

        public CompanyEntity AddOrUpdateCompany(CompanyEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.CompanyId > 0)
            {
                sqlStatement += "UPDATE Company SET  " + Environment.NewLine +
                "CompanyOwner=@CompanyOwner," + Environment.NewLine +
                "Description=@Description," + Environment.NewLine +
                "Deleted=@Deleted," + Environment.NewLine +
                "Address=@Address," + Environment.NewLine +
                "CompanyCode=@CompanyCode," + Environment.NewLine +
                "TaxCode=@TaxCode," + Environment.NewLine +
                "Website=@Website," + Environment.NewLine +
                "Phone=@Phone," + Environment.NewLine +
                "IsSupplier=@IsSupplier," + Environment.NewLine +
                "IsCustomer=@IsCustomer" + Environment.NewLine +
                "WHERE CompanyId=@CompanyId " + Environment.NewLine +
                "SELECT @CompanyId AS CompanyId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Company(  " + Environment.NewLine +
                "CompanyOwner," + Environment.NewLine +
                "Description," + Environment.NewLine +
                "Deleted," + Environment.NewLine +
                "Address," + Environment.NewLine +
                "CompanyCode," + Environment.NewLine +
                "TaxCode," + Environment.NewLine +
                "Website," + Environment.NewLine +
                "Phone," + Environment.NewLine +
                "IsSupplier," + Environment.NewLine +
                "IsCustomer)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@CompanyOwner," + Environment.NewLine +
                "@Description," + Environment.NewLine +
                "@Deleted," + Environment.NewLine +
                "@Address," + Environment.NewLine +
                "@CompanyCode," + Environment.NewLine +
                "@TaxCode," + Environment.NewLine +
                "@Website," + Environment.NewLine +
                "@Phone," + Environment.NewLine +
                "@IsSupplier," + Environment.NewLine +
                "@IsCustomer)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS CompanyId" + Environment.NewLine;
            }

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                entityObject.CompanyId = conn.ExecuteScalar<int>(sqlStatement, new
                {
                    Address = entityObject.Address,
                    CompanyCode = entityObject.CompanyCode,
                    CompanyId = entityObject.CompanyId,
                    CompanyOwner = entityObject.CompanyOwner,
                    Description = entityObject.Description,
                    IsCustomer = (entityObject.IsCustomer ? 1 : 0),
                    IsSupplier = (entityObject.IsSupplier ? 1 : 0),
                    Deleted = (entityObject.Deleted ? 1 : 0),
                    Phone = entityObject.Phone,
                    TaxCode = entityObject.TaxCode,
                    Website = entityObject.Website
                });
            }
            return entityObject;
        }
        public bool DeleteCompany(CompanyEntity entityObject)
        {
            string sqlStatement = "UPDATE Company SET Deleted=1 WHERE CompanyId=@CompanyId  " + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                conn.Execute(sqlStatement, new { CompanyId = entityObject.CompanyId });
            }
            return true;
        }
    }
}
