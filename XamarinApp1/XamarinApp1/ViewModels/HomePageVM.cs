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
            try
            {
                if (Helpers.Data.Employee.EmpID != Helpers.Data.User.EmpId)
                {
                    LoadEmployeeData();
                }
                else
                    Employee = Helpers.Data.Employee;
                //if (Helpers.Data.Employee != null)
                //{
                //    Employee = new Employee()
                //    {
                //        EmpID = Helpers.Data.Employee.EmpID,
                //        Department = Helpers.Data.Employee.Department,
                //        Branch = Helpers.Data.Employee.Branch,
                //        EmployeeName = Helpers.Data.Employee.EmployeeName,
                //        Designation = Helpers.Data.Employee.Designation,
                //        Section = Helpers.Data.Employee.Section
                //    };
                //}
                MenuItemList = new List<MenuItems>();
                MenuItemList = Helpers.Data.MenuItemList;
                MenuListCommand = new MenuListCommand();
                SelectedMenuItem = new MenuItems();
            }catch(Exception ex) 
{ }      
		}

        public async void LoadEmployeeData()
        {
            try
            {
                var employeeData = await LoginLogic.GetUserInfoResponse(Helpers.Data.User.EmpId);
                if (employeeData == null)
                {
                }
                else
                {
                    Helpers.Data.Employee = employeeData;
                    Employee = Helpers.Data.Employee;                    
                }
            }
            catch (Exception ex)
            {
            }

        }

    }
}