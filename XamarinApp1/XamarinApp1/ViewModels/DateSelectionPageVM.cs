using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp1.Commands;
using XamarinApp1.UserInterfaces;

namespace XamarinApp1.ViewModels
{
	public class DateSelectionPageVM : BaseViewModel
	{
        private DateTime _SelectedStartDate;

        public DateTime SelectedStartDate
        {
            get { return _SelectedStartDate; }
            set { _SelectedStartDate = value;
                OnPropertyChanged("SelectedStartDate");
                Helpers.Data.SelectedStartDate = SelectedStartDate;

            }
        }

        private DateTime _SelectedEndDate;

        public DateTime SelectedEndDate
        {
            get { return _SelectedEndDate; }
            set { _SelectedEndDate = value;
                OnPropertyChanged("SelectedEndDate");
                Helpers.Data.SelectedEndDate = SelectedEndDate;

            }
        }


        public LoadDataCommand LoadDataCommand { get; set; }

		public DateSelectionPageVM ()
		{
            SelectedStartDate = DateTime.Today;
            SelectedEndDate = DateTime.Today;
            LoadDataCommand = new LoadDataCommand(this);		
		}

        public void NavigateToAttendance()
        {

            App.Current.MainPage.Navigation.PushAsync(new AttendancePage(SelectedStartDate, _SelectedEndDate));
            //App.Current.MainPage = new NavigationPage( new  AttendancePage(SelectedStartDate, SelectedEndDate));
        }
	}
}