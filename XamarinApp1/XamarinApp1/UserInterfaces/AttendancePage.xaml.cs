using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp1.ViewModels;

namespace XamarinApp1.UserInterfaces
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttendancePage : ContentPage
	{
        AttendancePageVM viewModel { get; set; }
		public AttendancePage (DateTime SDate, DateTime EDate)
		{
			InitializeComponent ();
            viewModel = new AttendancePageVM(SDate, EDate);
            BindingContext = viewModel;
		}

    }
}