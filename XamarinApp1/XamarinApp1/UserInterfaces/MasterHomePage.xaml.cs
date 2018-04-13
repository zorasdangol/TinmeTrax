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
	public partial class MasterHomePage : ContentPage
	{
        public MasterHomePageVM viewModel { get; set; }
		public MasterHomePage ()
		{
			InitializeComponent ();
            viewModel = new MasterHomePageVM();
            BindingContext = viewModel;
            //viewModel.Employee = Helpers.Data.Employee;
		}

        protected override void OnAppearing()
        {
            
            base.OnAppearing();
        }
    }
}