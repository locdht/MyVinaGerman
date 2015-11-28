using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity.DatabaseEntity
{
    public class UserAccountEntity : VinaGerman.Entity.BaseEntity
    {
        #region Private properties
        private int _iUserAccountId;
        private string _sUserName;
        private string _sPassword;
        private int _iAccountType;       
        #endregion

        #region Public properties
        [DataMember]
        public int UserAccountId
        {
            get
            {
                return _iUserAccountId;
            }
            set
            {
                _iUserAccountId = value;
            }
        }

        [DataMember]
        public string UserName
        {
            get
            {
                return _sUserName;
            }
            set
            {
                _sUserName = value;
            }
        }

        [DataMember]
        public string Password
        {
            get
            {
                return _sPassword;
            }
            set
            {
                _sPassword = value;
            }
        }

        [DataMember]
        public int AccountType
        {
            get
            {
                return _iAccountType;
            }
            set
            {
                _iAccountType = value;
            }
        }     
        #endregion
    }
}
