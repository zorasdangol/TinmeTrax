using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp1.Models;
using XamarinApp1.ViewModels;

namespace XamarinApp1.UserInterfaces
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LeaveSummaryPage : ContentPage
	{
        
        public LeaveSummaryPageVM viewModel { get; set; }
		public LeaveSummaryPage ()
		{
			InitializeComponent ();
            viewModel = new LeaveSummaryPageVM();
            BindingContext = viewModel;
		}
	}
}