using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp1.Models
{
    public class Employee
    {
        public Employee()
        {
            EmpID = new int();
        }
        public int EmpID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Branch { get; set; }

        public static string GenerateUserInfoURL(int empid)
        {
            return string.Format(Helpers.Constants.ipAddress + Helpers.Constants.USERINFO_REQUEST_URL, empid);
        }
    }
}
