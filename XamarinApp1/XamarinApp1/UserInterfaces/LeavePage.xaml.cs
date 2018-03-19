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
	public partial class LeavePage : ContentPage
	{
        public LeavePageVM viewModel { get; set; }
		public LeavePage ()
		{
			InitializeComponent ();
            viewModel = new LeavePageVM();
            BindingContext = viewModel;
		}
	}
}