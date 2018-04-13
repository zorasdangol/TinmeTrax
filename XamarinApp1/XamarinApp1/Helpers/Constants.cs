using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp1.Helpers
{
    public class Constants
    {
        //public static string ipAddress = "host://amitpc";
        public  static string ipAddress = "http://192.168.0.11";
        public  static string LOGIN_REQUEST_URL = "/ttapi/api/login?empid={0}&pwd={1}";
        public  static string ATTENDANCE_REQUEST_URL = "/ttapi/api/attendance?empid={0}&SDate={1}&EDate={2}&flgAllData=0";
        public  static string LEAVE_REQUEST_URL = "/ttapi/api/leave?empid={0}";
        public  static string LEAVESUMMARY_REQUEST_URL = "/ttapi/api/LeaveSummary?empid={0}";
        public static string USERINFO_REQUEST_URL = "/ttapi/api/userinfo?empid={0}";
        public static string AUTHAPI_REQUEST_URL = "/ttapi/api/authapiurl?authpwd={0}";
    }
}
