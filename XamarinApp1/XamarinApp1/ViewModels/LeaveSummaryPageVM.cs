using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;

namespace XamarinApp1.ViewModels
{
	public class LeaveSummaryPageVM : BaseViewModel
	{
        private List<LeaveSummary> _LeaveSummaryList;

        public List<LeaveSummary> LeaveSummaryList
        {
            get { return _LeaveSummaryList; }
            set { _LeaveSummaryList = value; OnPropertyChanged("LeaveSummaryList"); }
        }


        public LeaveSummaryPageVM ()
		{
            LeaveSummaryList = new List<LeaveSummary>();
            LoadLeaveSummary();
        }


        public async void LoadLeaveSummary()
        {
            try
            {
                LeaveSummaryList = await LoginLogic.GetLeaveSummaryResponse(Helpers.Data.User.EmpId);
                if(LeaveSummaryList == null)
                { 
                    App.Current.MainPage = (new HomePage(0));
                }
            }
            catch (Exception ex)
            {         }
        }
	}
}