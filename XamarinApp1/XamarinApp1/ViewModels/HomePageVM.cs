using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp1.Commands;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;

namespace XamarinApp1.ViewModels
{
	public class HomePageVM: BaseViewModel
    {
        public List<MenuItems> MenuItemList { get; set; }
        public MenuListCommand MenuListCommand { get; set; }

        private MenuItems _SelectedMenuItem;

        public MenuItems SelectedMenuItem
        {
            get { return _SelectedMenuItem; }
            set {
                if (value == null)
                    return;
                if(_SelectedMenuItem != value)
                {
                    _SelectedMenuItem = value;
                    OnPropertyChanged("SelectedMenuItem");
                }
            } 
        }

        private Employee _Employee;

        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; OnPropertyChanged("Employee"); }
        }


        public HomePageVM ()
		{
            MenuItemList = new List<MenuItems>();
            MenuItemList = Helpers.Data.MenuItemList;            
            MenuListCommand = new MenuListCommand();
            SelectedMenuItem = new MenuItems();
            LoadEmployeeData();
		}      

        public  async void  LoadEmployeeData()
        {
            try
            {
                Helpers.Data.Employee = await LoginLogic.GetUserInfoResponse(Helpers.Data.User.EmpId);
                Employee = Helpers.Data.Employee;
                //SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                //var a = conn.Table<Employee>().ToList();
                //conn.CreateTable<Employee>();
                //int rows = conn.Insert(Employee);
                //conn.Close();
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
    
        }

    }
}