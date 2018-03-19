using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp1.Models
{
    public class User:BaseModel
    {
        private int _EmpId;

        public int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value; OnPropertyChanged("EmpId"); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged("Password"); }
        }

        private string _ConfirmPassword;

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { _ConfirmPassword = value; OnPropertyChanged("ConfirmPassword"); }
        }
        
        public static string GenerateLoginURL(int empid, string pwd)
        {
            return string.Format(Helpers.Constants.ipAddress + Helpers.Constants.LOGIN_REQUEST_URL, empid, pwd);
        }
    }
}
