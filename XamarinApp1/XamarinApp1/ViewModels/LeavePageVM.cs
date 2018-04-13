using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;
using Xamarin.Forms;

namespace XamarinApp1.ViewModels
{
    public class LeavePageVM : BaseViewModel
    {
        private List<Leave> _LeaveList;

        public List<Leave> LeaveList
        {
            get { return _LeaveList; }
            set { _LeaveList = value; OnPropertyChanged("LeaveList"); }
        }

        public LeavePageVM()
        {
            LeaveList = new List<Leave>();
            LoadLeave();
        }

        public double balance = 0;
        public double taken = 0;
        public async void LoadLeave()
        {
            try
            {
                LeaveList = await LoginLogic.GetLeaveResponse(Helpers.Data.User.EmpId);
                if(LeaveList == null)
                { 
                    App.Current.MainPage = (new HomePage(0));
                }
                foreach(var i in LeaveList)
                {                   
                    int index = i.LeaveOn.IndexOf(" ");
                    if (index > 0)
                        i.LeaveOn = i.LeaveOn.Substring(0, index);

                    if (!string.IsNullOrEmpty(i.Given))
                    {
                        if (Convert.ToDouble(i.Given) != 0)
                            balance = Convert.ToDouble(i.Given);
                        //else
                        //    i.Given = Convert.ToString(given);
                    }
                    if (!string.IsNullOrEmpty(i.Taken))
                    {
                        taken = Convert.ToDouble(i.Taken);
                    }
                    else
                    {
                        taken = 0;
                    }
                    i.Balance = balance - taken;
                    balance = i.Balance;                                           
                }
            }
            catch (Exception ex)    {            }
        }
    }
}
