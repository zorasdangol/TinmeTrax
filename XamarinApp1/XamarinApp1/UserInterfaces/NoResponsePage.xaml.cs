using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp1.UserInterfaces
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoResponsePage : ContentPage
	{
		public NoResponsePage ()
		{
			InitializeComponent ();
		}

        private void ReconnectBT_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Helpers.Data.User.EmpId == 0)
                {
                    App.Current.MainPage = new MainPage();
                }
                else
                {
                    App.Current.MainPage = new HomePage();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}