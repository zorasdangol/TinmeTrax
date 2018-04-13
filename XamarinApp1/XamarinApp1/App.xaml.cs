using Microsoft.WindowsAzure.MobileServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;

namespace XamarinApp1
{
	public partial class App : Application
	{
        public static string DatabaseLocation = string.Empty;

      public App ()
		{
            Helpers.Data.Employee = new Employee();
            Helpers.Data.User = new User();
			InitializeComponent();
        
            MainPage =(new XamarinApp1.MainPage());
		}
        public App(string databaseLocation)
        {
            Helpers.Data.Employee = new Employee();
            Helpers.Data.User = new User();
            InitializeComponent();

            DatabaseLocation = databaseLocation;

            try
            { 
                SQLiteConnection conn = new SQLiteConnection(DatabaseLocation);
                conn.CreateTable<User>();
                var userRow = conn.Table<User>().ToList();
                var UserData = conn.Query<User>("Select * from User");
                //LoadEmployeeData();
                if (userRow.Count > 0)
                {
                    Helpers.Data.User = UserData.FirstOrDefault();
                    conn.CreateTable<API>();
                    var apiRow = conn.Table<API>().ToList();
                    var ApiData = conn.Query<API>("Select * from API");
                    if (apiRow.Count > 0)
                    {
                        Helpers.Constants.ipAddress = ApiData.FirstOrDefault().ipAddress;
                        string ip = Helpers.Constants.ipAddress;
                    }
                    else
                    {
                        API obj = new API { ipAddress = Helpers.Constants.ipAddress };
                        conn.Insert(obj);
                    }
                    MainPage = (new HomePage());
                }
                else
                {
                    MainPage =new NavigationPage (new MainPage());
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error",ex.Message,"OK");
            }
        }

        public async void LoadEmployeeData()
        {
            try
            {
                var employeeData = await LoginLogic.GetUserInfoResponse(Helpers.Data.User.EmpId);
                if (employeeData == null)
                {
                    App.Current.MainPage = new HomePage(0);
                }
                else
                {
                    Helpers.Data.Employee = employeeData;
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
