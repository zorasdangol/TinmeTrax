using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp1.Commands;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;
using XamarinApp1.ViewModels;

namespace XamarinApp1.ViewModels
{
    public class MainPageVM:BaseViewModel
    {
        private User _User;

        public User User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged("User"); }
        }

        public MainPageCommand mainPageCommand { get; set; }

        public SignUpCommand signUpCommand { get; set; }

        private int _EmpId;

        public int EmpId
        {
            get { return _EmpId; }
            set { _EmpId = value;
                User = new User()
                {
                    EmpId = this.EmpId,
                    Password = this.Password   
                };
                OnPropertyChanged("EmpId"); }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value;
                User = new User()
                {
                    EmpId = this.EmpId,
                    Password = this.Password
                };
                OnPropertyChanged("Password"); }
        }



        public MainPageVM()
        {            
            try {                
                User = new User();
                Helpers.Data.User = new User();
                mainPageCommand = new MainPageCommand(this);
                signUpCommand = new SignUpCommand(this);
            }catch(Exception ex) { App.Current.MainPage.DisplayAlert("Error",ex.Message,"OK"); }
            }

        public async void Login()
        {
            try
            {
                string loginResult = await LoginLogic.GetLoginResponse(User.EmpId, User.Password);
                if (loginResult == "true")
                {
                    Helpers.Data.User = User;
                    SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                    conn.CreateTable<User>();
                    conn.Execute("Delete from User");
                    int rows = conn.Insert(User);
                    conn.Close();
                    if (rows == 1)
                    {                       
                        App.Current.MainPage = (new HomePage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Failed to Log In ", "OK");
                    }
                }

                else if (loginResult == "false")
                    await App.Current.MainPage.DisplayAlert("Error", "Employee ID or Password incorrect", "OK");
            }
            catch (Exception ex) {  }
        }

        public async void SignUp()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ApiPasswordPage());
        }
    }
}
