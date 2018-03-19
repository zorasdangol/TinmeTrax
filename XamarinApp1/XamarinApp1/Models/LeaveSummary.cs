using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp1.Models
{
    public class LeaveSummary
    {
        public string LeaveName { get; set; }
        public double Given { get; set; }
        public double Taken { get; set; }
        public double Balance { get; set; }

        public static string GenerateLeaveSummaryURL(int empid)
        {
            return string.Format(Helpers.Constants.ipAddress + Helpers.Constants.LEAVESUMMARY_REQUEST_URL, empid);
        }
    }

   
}
