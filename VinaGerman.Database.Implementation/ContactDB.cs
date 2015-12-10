using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity.BusinessEntity;
using VinaGerman.Entity.SearchEntity;
using Dapper;
using VinaGerman.Entity.DatabaseEntity;
namespace VinaGerman.Database.Implementation
{
    public class ContactDB : BaseDB, IContactDB
    {
        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> SearchContact(ContactSearchEntity searchObject)
        {
            List<VinaGerman.Entity.BusinessEntity.ContactEntity> result = null;            
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Contact.ContactId," + Environment.NewLine +
                "Contact.FullName," + Environment.NewLine +
                "Contact.Email," + Environment.NewLine +
                "Contact.Phone," + Environment.NewLine +
                "Contact.Address," + Environment.NewLine +
                "Contact.CompanyId," + Environment.NewLine +
                "Contact.UserAccountId," + Environment.NewLine +
                "Contact.Position," + Environment.NewLine +
                "Contact.DepartmentId," + Environment.NewLine +
                "Contact.Deleted" + Environment.NewLine +
                "FROM Contact " + Environment.NewLine +
                "WHERE Deleted=0 " + Environment.NewLine;
            if (searchObject.SearchText != null && searchObject.SearchText.Length > 0)
            {
                sqlStatement += "AND (FullName LIKE N'%" + searchObject.SearchText + "%' OR Phone LIKE N'%" + searchObject.SearchText + "%' OR Email LIKE N'%" + searchObject.SearchText + "%' OR Address LIKE N'%" + searchObject.SearchText + "%')" + Environment.NewLine;
            }
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<VinaGerman.Entity.BusinessEntity.ContactEntity>(sqlStatement).ToList();
            }
            return result;
        }

        public VinaGerman.Entity.BusinessEntity.ContactEntity AddOrUpdateContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            string sqlStatement = "";
            //if insert
            if (entityObject.ContactId > 0)
            {
                sqlStatement += "UPDATE Contact SET  " + Environment.NewLine +
                "FullName=@FullName," + Environment.NewLine +
                "Email=@Email," + Environment.NewLine +
                "Phone=@Phone," + Environment.NewLine +
                "Address=@Address," + Environment.NewLine +
                "CompanyId=@CompanyId," + Environment.NewLine +
                "UserAccountId=@UserAccountId," + Environment.NewLine +
                "Position=@Position," + Environment.NewLine +
                "DepartmentId=@DepartmentId," + Environment.NewLine +
                "Deleted=@Deleted" + Environment.NewLine +
                "WHERE ContactId=@ContactId " + Environment.NewLine +
                "SELECT @ContactId AS ContactId " + Environment.NewLine;
            }
            else
            {
                sqlStatement += "INSERT INTO Contact(  " + Environment.NewLine +
                "FullName," + Environment.NewLine +
                "Email," + Environment.NewLine +
                "Phone," + Environment.NewLine +
                "Address," + Environment.NewLine +
                "CompanyId," + Environment.NewLine +
                "UserAccountId," + Environment.NewLine +
                "Position," + Environment.NewLine +
                "DepartmentId," + Environment.NewLine +
                "Deleted)" + Environment.NewLine +
                "VALUES (" + Environment.NewLine +
                "@FullName," + Environment.NewLine +
                "@Email," + Environment.NewLine +
                "@Phone," + Environment.NewLine +
                "@Address," + Environment.NewLine +
                "@CompanyId," + Environment.NewLine +
                "@UserAccountId," + Environment.NewLine +
                "@Position," + Environment.NewLine +
                "@DepartmentId," + Environment.NewLine +
                "@Deleted)" + Environment.NewLine +
                "SELECT SCOPE_IDENTITY() AS ContactId" + Environment.NewLine;
            }

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                entityObject.ContactId = conn.ExecuteScalar<int>(sqlStatement, new
                {
                    ContactId = entityObject.ContactId,
                    FullName = entityObject.FullName,
                    Email = entityObject.Email,
                    Phone = entityObject.Phone,
                    Address = entityObject.Address,
                    CompanyId = entityObject.CompanyId,
                    UserAccountId = entityObject.UserAccountId,
                    Position = entityObject.Position,
                    DepartmentId = entityObject.DepartmentId,
                    Deleted = (entityObject.Deleted ? 1 : 0)
                });
            }
            return entityObject;
        }

        public bool DeleteContact(VinaGerman.Entity.BusinessEntity.ContactEntity entityObject)
        {
            string sqlStatement = "UPDATE Contact SET Deleted=1 WHERE ContactId=@ContactId  " + Environment.NewLine;

            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                conn.Execute(sqlStatement, new { ContactId = entityObject.ContactId });
            }
            return true;
        }

        public List<VinaGerman.Entity.BusinessEntity.ContactEntity> GetContactForCompany(CompanyEntity hObject)
        {
            List<VinaGerman.Entity.BusinessEntity.ContactEntity> result = null;
            string sqlStatement = "SELECT " + Environment.NewLine +
                "Contact.ContactId," + Environment.NewLine +
                "Contact.FullName," + Environment.NewLine +
                "Contact.Email," + Environment.NewLine +
                "Contact.Phone," + Environment.NewLine +
                "Contact.Address," + Environment.NewLine +
                "Contact.CompanyId," + Environment.NewLine +
                "Contact.UserAccountId," + Environment.NewLine +
                "Contact.Position," + Environment.NewLine +
                "Contact.DepartmentId," + Environment.NewLine +
                "Contact.Deleted" + Environment.NewLine +
                "FROM Contact join Company on Contact.CompanyId= Company.CompanyId" + Environment.NewLine +
                "WHERE Deleted=0 and Contact.CompanyId=@CompanyId" + Environment.NewLine;
            //execute
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                result = conn.Query<VinaGerman.Entity.BusinessEntity.ContactEntity>(sqlStatement).ToList();
            }
            return result;
        }
    }
}
