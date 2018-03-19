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
			InitializeComponent();
        
            MainPage = new XamarinApp1.MainPage();
		}
        public App(string databaseLocation)
        {
            InitializeComponent();

            DatabaseLocation = databaseLocation;

            try
            { 
                SQLiteConnection conn = new SQLiteConnection(DatabaseLocation);
                conn.CreateTable<User>();
                conn.CreateTable<API>();
                conn.CreateTable<Employee>();
                var userRow = conn.Table<User>().ToList();
                var apiRow = conn.Table<API>().ToList();
                var employeeRow = conn.Table<Employee>().ToList();
                var UserData = conn.Query<User>("Select * from User");
                var ApiData = conn.Query<API>("Select * from API");
                var EmployeeData = conn.Query<Employee>("Select * from Employee");
                conn.Close();

                if (userRow.Count == 1 && apiRow.Count == 1)
                {
                    Helpers.Data.User = UserData.FirstOrDefault();
                    Helpers.Constants.ipAddress = ApiData.FirstOrDefault().ipAddress;

                    MainPage = new HomePage();
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage());
                }
            }
            catch(Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error",ex.Message,"OK");
            }

        }

        public async void LoadEmployee()
        {
            Helpers.Data.Employee = await LoginLogic.GetUserInfoResponse(Helpers.Data.User.EmpId);
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
