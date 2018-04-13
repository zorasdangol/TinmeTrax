using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;

namespace XamarinApp1.ViewModels
{
    class AttendancePageVM : BaseViewModel
    {
        private List<Attendance> _AttendanceList;

        public List<Attendance> AttendanceList
        {
            get { return _AttendanceList; }
            set { _AttendanceList = value; OnPropertyChanged("AttendanceList"); }
        }

        public AttendancePageVM(DateTime SDate, DateTime EDate )
        {
            AttendanceList = new List<Attendance>();
            LoadAttendanceList(SDate, EDate);
        }

        public async void LoadAttendanceList(DateTime SDate, DateTime EDate)
        {
            try
            {
                AttendanceList = await LoginLogic.GetAttendanceResponse(Helpers.Data.User.EmpId, SDate.Date , EDate.Date) ;
                if(AttendanceList == null)
                {
                    App.Current.MainPage = (new HomePage(0));
                }
                foreach(var attendance in AttendanceList)
                {
                    if (string.IsNullOrEmpty(attendance.OutTime))
                    {
                        attendance.TDate_Out = "";                        
                    }
                }
            }
            catch (Exception ex)  {      }
        }
    }
}
