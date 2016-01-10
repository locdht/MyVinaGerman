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
            using (DbCommand sqlCmd = DatabaseProvider.GetSqlStringCommand(sqlStatement))
            {
                DatabaseProvider.AddInParameter(sqlCmd, "UserId", DbType.Int32, iUserId);
                DatabaseProvider.AddInParameter(sqlCmd, "UserName", DbType.String, sUserName);
                DatabaseProvider.AddInParameter(sqlCmd, "FullName", DbType.String, sFullName);
                DatabaseProvider.AddInParameter(sqlCmd, "Position", DbType.String, sPosition);
                DatabaseProvider.AddInParameter(sqlCmd, "Phone", DbType.String, sPhone);

                result = DatabaseProvider.ExecuteNonQuery(sqlCmd);
            }
            return result;            
        }

        public UserProfileEntity GetUserProfileByUserName(string sUserName)
        {
            IEnumerable<UserProfileEntity> list = null;
            string sqlStatement = "SELECT TOP 1 * FROM UserProfile WHERE UserName=@UserName " + Environment.NewLine;
            
            using (DbCommand sqlCmd = DatabaseProvider.GetSqlStringCommand(sqlStatement))
            {
                DatabaseProvider.AddInParameter(sqlCmd, "UserName", DbType.String, sUserName);
                                
                // Call the ExecuteReader method with the command.                
                list = Connection.Query<UserProfileEntity>(sqlStatement, new { UserName = sUserName });
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

            list = Connection.Query<UserProfileEntity>(sqlStatement, new { UserName = sUserName, Password = MD5Hash(sPassword) });
            result = list.FirstOrDefault<UserProfileEntity>();
            if (result != null)
            {
                //return original password
                result.Password = sPassword;
            }
            return result;
        }
    }
}
