using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp1.Models
{
    public class API
    {
        public string ipAddress { get; set; }

        public static string GenerateAuthApiURL(string ipAddress , string pwd)
        {
            return string.Format(ipAddress + Helpers.Constants.AUTHAPI_REQUEST_URL, pwd);
        }
    }
    
   
}
