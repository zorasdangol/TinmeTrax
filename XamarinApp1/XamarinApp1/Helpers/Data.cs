using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinApp1.Models;

namespace XamarinApp1.Helpers
{
    public class Data:BaseModel
    {
        public static DateTime SelectedStartDate { get; set; }
        public static DateTime SelectedEndDate { get; set; }
        public static User User { get; set; }

        public static Employee Employee { get; set;}
        public static bool Conn { get; set; }


        public static List<MenuItems> MenuItemList = new List<MenuItems> {
            new MenuItems{ Index = 1, Icon = "attendance.png" , Name = "Check Attendance" },
            new MenuItems{ Index = 2, Icon = "leave.png" ,  Name =  "Leave Details" },
            new MenuItems{ Index = 3, Icon = "leaveSummary.png" ,  Name = "Leave Summary" },
            new MenuItems{ Index = 4, Icon = "ipAddress.png" ,  Name = "IP Address Change"},
            new MenuItems{ Index = 5, Icon = "logout.png" ,  Name = "Logout"},
            new MenuItems{ Index = 6, Icon = "about.png" ,  Name = "About Us"}
        };

      
    }
}
