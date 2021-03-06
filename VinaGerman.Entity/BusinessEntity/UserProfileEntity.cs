﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;

namespace VinaGerman.Entity.BusinessEntity
{
    public class UserProfileEntity : BaseEntity
    {
        #region Private properties
        private int _iContactId;
        private int _iCompanyId;
        private int _iDepartmentId;
        private int _iUserAccountId;
        private int _iDeleted;
        private string _sFullName;
        private string _sEmail;
        private string _sPhone;
        private string _sAddress;
        private string _sPosition;

        private string _sUserName;
        private string _sPassword;
        private int _iAccountType;    
        #endregion

        #region Public properties
        [DataMember]
        public int ContactId
        {
            get
            {
                return _iContactId;
            }
            set
            {
                _iContactId = value;
            }
        }
        [DataMember]
        public int CompanyId
        {
            get
            {
                return _iCompanyId;
            }
            set
            {
                _iCompanyId = value;
            }
        }
        [DataMember]
        public int DepartmentId
        {
            get
            {
                return _iDepartmentId;
            }
            set
            {
                _iDepartmentId = value;
            }
        }
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
        public int Deleted
        {
            get
            {
                return _iDeleted;
            }
            set
            {
                _iDeleted = value;
            }
        }

        [DataMember]
        public string FullName
        {
            get
            {
                return _sFullName;
            }
            set
            {
                _sFullName = value;
            }
        }

        [DataMember]
        public string Email
        {
            get
            {
                return _sEmail;
            }
            set
            {
                _sEmail = value;
            }
        }
        [DataMember]
        public string Address
        {
            get
            {
                return _sAddress;
            }
            set
            {
                _sAddress = value;
            }
        }
        [DataMember]
        public string Phone
        {
            get
            {
                return _sPhone;
            }
            set
            {
                _sPhone = value;
            }
        }

        [DataMember]
        public string Position
        {
            get
            {
                return _sPosition;
            }
            set
            {
                _sPosition = value;
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
