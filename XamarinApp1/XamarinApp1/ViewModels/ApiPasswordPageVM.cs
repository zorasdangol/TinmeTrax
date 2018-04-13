using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinApp1.Commands;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;

namespace XamarinApp1.ViewModels
{
    public class ApiPasswordPageVM : BaseViewModel
    {
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged("Password"); }
        }

        private string _ip1;

        public string ip1
        {
            get { return _ip1; }
            set { _ip1 = value; OnPropertyChanged("ip1"); }
        }

        private string _ip2;

        public string ip2
        {
            get { return _ip2; }
            set { _ip2 = value; OnPropertyChanged("ip2"); }
        }
        private string _ip3;

        public string ip3
        {
            get { return _ip3; }
            set { _ip3 = value; OnPropertyChanged("ip3"); }
        }
        private string _ip4;

        public string ip4
        {
            get { return _ip4; }
            set { _ip4 = value; OnPropertyChanged("ip4"); }
        }

        private string _Port;

        public string Port
        {
            get { return _Port; }
            set { _Port = value; OnPropertyChanged("Port"); }
        }
        public string ip { get; set; }

        public string ipAddress { get; set; }

        public ApiPasswordCommand ApiPasswordCommand { get; set; }
        
        public ApiPasswordPageVM()
        {
            ip = Helpers.Constants.ipAddress;
            ip1 = "192";
            ip2 = "168";
            ip3 = "0";
            ip4 = "131";
            ApiPasswordCommand = new ApiPasswordCommand(this);
        }

        public async void NavigateApiPage()
        {
            try
            {
                if (string.IsNullOrEmpty(ip1) || string.IsNullOrEmpty(ip2) || string.IsNullOrEmpty(ip3) || string.IsNullOrEmpty(ip4))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Fill the ip address", "OK");
                }
                else
                {
                    if (string.IsNullOrEmpty(Port))
                    {
                        ipAddress = "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4;
                    }
                    else
                    {
                        ipAddress = "http://" + ip1 + "." + ip2 + "." + ip3 + "." + ip4 + ":" + Port;
                    }
                    string apiResult = await LoginLogic.GetAuthApiResponse(ipAddress, Password);
                    if(apiResult == null)
                    {
                        //App.Current.MainPage.Navigation.PushAsync(new NoResponsePage());
                    }
                    if (apiResult == "true")
                    {
                        API api = new API
                        {
                            ipAddress = this.ipAddress
                        };
                        SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                        conn.CreateTable<API>();
                        conn.Execute("delete from API");
                        int rows = conn.Insert(api);
                        conn.Close();
                        Helpers.Constants.ipAddress = ipAddress;
                        App.Current.MainPage = new NavigationPage(new MainPage());
                        await App.Current.MainPage.DisplayAlert("Success","API Url set correctly","Ok");
                    }
                    else if (apiResult == "false")
                        await App.Current.MainPage.DisplayAlert("Error", "Url or Password incorrect", "OK");
                }
            }
            catch (Exception ex) {  }

        }
    }
}
