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
    public class MasterHomePageVM:BaseViewModel
    {
        private Employee _Employee;

        public Employee Employee
        {
            get { return _Employee; }
            set { _Employee = value; OnPropertyChanged("Employee"); }
        }
        public MasterHomePageCommand MasterHomePageCommand { get; set; }

        public MasterHomePageVM()
        {
            try
            {
                if (Helpers.Data.User.EmpId == Helpers.Data.Employee.EmpID)
                {
                    Employee = Helpers.Data.Employee;
                }
                else
                {
                    LoadEmployeeData();
                }
                MasterHomePageCommand = new MasterHomePageCommand(this);
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
                    App.Current.MainPage = new HomePage(0);
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

        public void NavigateTo(int index)
        {
            try
            {
                switch (index)
                {
                    case 0:
                        App.Current.MainPage = (new HomePage() );
                        break;
                    case 1:
                        App.Current.MainPage = (new HomePage() { Detail = new NavigationPage(new DateSelectionPage()) });
                        break;
                    case 2:
                        App.Current.MainPage = (new HomePage() { Detail = new NavigationPage(new LeavePage()) });

                        break;
                    case 3:
                        App.Current.MainPage = (new HomePage() { Detail = new NavigationPage(new LeaveSummaryPage()) });

                        break;
                }

            }catch(Exception ex) { App.Current.MainPage.DisplayAlert("Error","App dismiss Error " + ex.Message,"OK"); }
            
        }
        

    }
}
