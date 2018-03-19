using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinApp1.Models
{
    public class Attendance:BaseModel
    {
        public string Tdate { get; set; }
        public string TDate_Out { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string DayStatus { get; set; }

        public static string GenerateAttendanceURL(int empid,DateTime SDate,DateTime EDate)
        {
            return string.Format(Helpers.Constants.ipAddress + Helpers.Constants.ATTENDANCE_REQUEST_URL, empid,SDate.ToString("M/d/yyyy"), EDate.ToString("M/d/yyyy"));
        }
    }
}