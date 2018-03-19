using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp1.Models
{
    public class Leave
    {
        public string LeaveName { get; set; }
        public string LeaveOn { get; set; }
        public string Given { get; set; }
        public string Taken { get; set; }
        public double Balance { get; set; }
        public string Remarks { get; set; }

        public static string GenerateLeaveURL(int empid)
        {
            return string.Format(Helpers.Constants.ipAddress +  Helpers.Constants.LEAVE_REQUEST_URL, empid);
        }
    }
}
