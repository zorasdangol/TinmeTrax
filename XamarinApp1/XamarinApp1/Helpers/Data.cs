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


        public static List<MenuItems> MenuItemList = new List<MenuItems> {
            new MenuItems{ Index = 1, Name = "Check Attendance" },
            new MenuItems{ Index = 2, Name =  "Leave Details" },
            new MenuItems{ Index = 3, Name = "Leave Summary" },
            new MenuItems{ Index = 4, Name = "IP Address Change"},
            new MenuItems{ Index = 5, Name = "Logout"},
            new MenuItems{ Index = 6, Name = "About Us"}
        };

      
    }
}
