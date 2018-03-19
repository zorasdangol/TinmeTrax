using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinApp1.Commands;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;
using XamarinApp1.ViewModels;

namespace XamarinApp1.ViewModels
{
	public class RegisterPageVM : BaseViewModel
	{
        private User _User;

        public User User
        {
            get { return _User; }
            set {
                _User = value;
                OnPropertyChanged("User");
            }
        }


        public RegisterCommand registerCommand { get; set; }

        private int _EmpId;

        public int EmpId
        {
            get { return _EmpId; }
            set {
                _EmpId = value;
                User = new User() {
                    EmpId = this.EmpId,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword            
                };
                OnPropertyChanged("EmpId");
            }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value;
                User = new User()
                {
                    EmpId = this.EmpId,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string _ConfirmPassword;

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { _ConfirmPassword = value;
                User = new User()
                {
                    EmpId = this.EmpId,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }

        public RegisterPageVM ()
		{
            registerCommand = new RegisterCommand(this);
		}

        public async void Register()
        {
           // await App.MobileService.GetTable<User>().InsertAsync(User);
           await App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

	}
}