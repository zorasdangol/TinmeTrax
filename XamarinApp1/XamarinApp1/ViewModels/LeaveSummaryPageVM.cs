using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp1.Logic;
using XamarinApp1.Models;

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
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
	}
}