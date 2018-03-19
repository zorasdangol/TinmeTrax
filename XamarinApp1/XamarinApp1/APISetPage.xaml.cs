using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp1.Models;

namespace XamarinApp1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class APISetPage : ContentPage
	{
		public APISetPage ()
		{
			InitializeComponent ();
            ip1.Text = "192";
            ip2.Text = "168";
            ip3.Text = "0"; ;
            ip4.Text = "111";
		}

        private void SetBT_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ip1.Text) || string.IsNullOrEmpty(ip2.Text) || string.IsNullOrEmpty(ip3.Text) || string.IsNullOrEmpty(ip4.Text))
                {
                    DisplayAlert("Error", "Fill the ip address", "OK");

                }
                else
                {
                    if (string.IsNullOrEmpty(port.Text))
                    {
                        string ipAddress = "http://" + ip1.Text + "." + ip2.Text + "." + ip3.Text + "." + ip4.Text;
                        Helpers.Constants.ipAddress = ipAddress;
                    }
                    else
                    {
                        string ipAddress = "http://" + ip1.Text + "." + ip2.Text + "." + ip3.Text + "." + ip4.Text + ":" + port.Text;
                        Helpers.Constants.ipAddress = ipAddress;
                    }
                    API api = new API
                    {
                        ipAddress = Helpers.Constants.ipAddress
                    };
                    SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                    conn.CreateTable<API>();
                    int rows = conn.Insert(api);
                    conn.Close();
                    if(Helpers.Data.User != null)
                    {
                        App.Current.MainPage = new NavigationPage(new MainPage());
                    }
                    else
                    {
                        App.Current.MainPage.Navigation.PushAsync(new MainPage());
                    }
                }
            }catch(Exception ex) { App.Current.MainPage.DisplayAlert("Error",ex.Message,"OK"); }
        }
    }
}