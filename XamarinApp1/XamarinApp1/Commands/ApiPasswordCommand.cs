using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamarinApp1.ViewModels;

namespace XamarinApp1.Commands
{
    public class ApiPasswordCommand : ICommand
    {
        public ApiPasswordPageVM viewModel { get; set; }
        public ApiPasswordCommand(ApiPasswordPageVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            string Password = (string)parameter;
            if (Password == null)
                return false;
            if (string.IsNullOrEmpty(Password))
                return false;
            else
                return true;
        }

        public void Execute(object parameter)
        {
            viewModel.NavigateApiPage();
        }
    }
}
