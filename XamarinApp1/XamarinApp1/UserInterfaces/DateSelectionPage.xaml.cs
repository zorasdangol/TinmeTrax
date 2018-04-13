using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp1.Commands;
using XamarinApp1.ViewModels;

namespace XamarinApp1.UserInterfaces
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DateSelectionPage : ContentPage
	{
        public DateSelectionPageVM viewModel { get; set; }
		public DateSelectionPage ()
		{
			InitializeComponent ();
            viewModel = new DateSelectionPageVM();
            BindingContext = viewModel;
		}

        private void LoadData_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AttendancePage(Helpers.Data.SelectedStartDate,Helpers.Data.SelectedEndDate));
        }

    }
}