using Microsoft.Practices.EnterpriseLibrary.Data;
using VinaGerman.Database;
using VinaGerman.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Security.Cryptography;
using VinaGerman.Entity.BusinessEntity;

namespace VinaGerman.Database.Implementation
{
    public class UserDB  : BaseDB, IUserDB
    {
        public UserDB() { }

        public int AddOrUpdateUserProfile(int iUserId, string sUserName, string sFullName, string sPosition, string sPhone)
        {
            // Read data with a SQL statement that accepts one parameter prefixed with @.
            string sqlStatement = "DELETE FROM UserProfile WHERE UserId=@UserId " + Environment.NewLine;
            sqlStatement += "INSERT INTO UserProfile(UserId,UserName,FullName,Position,Phone) values(@UserId,@UserName,@FullName,@Position,@Phone)";
            int result = -1;
            // Create a suitable command type and add the required parameter.
            var db = GetDatabaseInstance();

            using (DbCommand sqlCmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(sqlCmd, "UserId", DbType.Int32, iUserId);
                db.AddInParameter(sqlCmd, "UserName", DbType.String, sUserName);
                db.AddInParameter(sqlCmd, "FullName", DbType.String, sFullName);
                db.AddInParameter(sqlCmd, "Position", DbType.String, sPosition);
                db.AddInParameter(sqlCmd, "Phone", DbType.String, sPhone);
                
                result = db.ExecuteNonQuery(sqlCmd);
            }
            return result;            
        }

        public UserProfileEntity GetUserProfileByUserName(string sUserName)
        {
            IEnumerable<UserProfileEntity> list = null;
            string sqlStatement = "SELECT TOP 1 * FROM UserProfile WHERE UserName=@UserName " + Environment.NewLine;
            var db = GetDatabaseInstance();            
            using (DbCommand sqlCmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(sqlCmd, "UserName", DbType.String, sUserName);
                                
                // Call the ExecuteReader method with the command.                
                using (IDbConnection conn = db.CreateConnection())
                {
                    list = conn.Query<UserProfileEntity>(sqlStatement, new { UserName = sUserName });
                }
            }
            return list.FirstOrDefault<UserProfileEntity>();
        }
        private string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public bool Login(string sUserName, string sPassword)
        {
            var account = GetUserProfile(sUserName,sPassword);
            return (account != null && account.UserAccountId > 0 && account.ContactId > 0);
        }

        public UserProfileEntity GetUserProfile(string sUserName, string sPassword)
        {
            UserProfileEntity result = null;
            IEnumerable<UserProfileEntity> list = null;
            string sqlStatement = "SELECT TOP 1  " + Environment.NewLine +
                "Contact.ContactId," + Environment.NewLine +
                "Contact.CompanyId," + Environment.NewLine +
                "Contact.DepartmentId," + Environment.NewLine +
                "Contact.UserAccountId," + Environment.NewLine +
                "Contact.Deleted," + Environment.NewLine +
                "Contact.Phone," + Environment.NewLine +
                "Contact.Address," + Environment.NewLine +
                "Contact.FullName," + Environment.NewLine +
                "Contact.Email," + Environment.NewLine +
                "Contact.Position," + Environment.NewLine +
                "UserAccount.UserName," + Environment.NewLine +
                "UserAccount.AccountType" + Environment.NewLine +
                "FROM UserAccount JOIN Contact ON UserAccount.UserAccountId=Contact.UserAccountId" + Environment.NewLine +
                "WHERE UserName=@UserName AND Password=@Password" + Environment.NewLine;            
            var db = GetDatabaseInstance();
            // Get a GetSqlStringCommandWrapper to specify the query and parameters                
            // Call the ExecuteReader method with the command.                
            using (IDbConnection conn = db.CreateConnection())
            {
                list = conn.Query<UserProfileEntity>(sqlStatement, new { UserName = sUserName, Password = MD5Hash(sPassword) });
                result = list.FirstOrDefault<UserProfileEntity>();
                if (result != null)
                {
                    //return original password
                    result.Password = sPassword;
                }
            }
            return result;
        }
    }
}
