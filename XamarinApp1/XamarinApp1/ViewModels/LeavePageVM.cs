using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp1.Logic;
using XamarinApp1.Models;

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

        public async void LoadLeave()
        {
            try
            {
                LeaveList = await LoginLogic.GetLeaveResponse(Helpers.Data.User.EmpId);
                foreach(var i in LeaveList)
                {
                    int index = i.LeaveOn.IndexOf(" ");
                    if (index > 0)
                        i.LeaveOn = i.LeaveOn.Substring(0, index);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
