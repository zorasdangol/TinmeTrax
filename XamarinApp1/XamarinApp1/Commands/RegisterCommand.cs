using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp1.Models;
using XamarinApp1.ViewModels;

namespace XamarinApp1.Commands
{
    public class RegisterCommand : ICommand
    {
        public RegisterPageVM viewModel { get; set; }

        public RegisterCommand(RegisterPageVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            User user = (User)parameter;

            if (user == null)
                return false;

            if (user.EmpId == 0 || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword))
                return false;

            if ((user.Password != user.ConfirmPassword) || (user.Password.Length < 6))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Register();
        }
    }
}
