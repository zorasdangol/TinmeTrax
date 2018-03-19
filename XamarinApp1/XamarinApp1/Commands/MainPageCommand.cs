using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamarinApp1.Models;
using XamarinApp1.ViewModels;

namespace XamarinApp1.Commands
{
    public class MainPageCommand : ICommand
    {
        public MainPageVM viewModel { get; set; }

        public MainPageCommand(MainPageVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var user = (User)parameter;

            if (user == null)
                return false;
            if (user.EmpId == 0 || string.IsNullOrEmpty(user.Password))
                return false;
            return true;
        }

        public  void Execute(object parameter)
        {
            viewModel.Login();
        }
    }
}
