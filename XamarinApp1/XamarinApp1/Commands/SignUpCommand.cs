using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinApp1.ViewModels;

namespace XamarinApp1.Commands
{
	public class SignUpCommand : ICommand
	{
        public MainPageVM viewModel { get;  set; } 

		public SignUpCommand (MainPageVM viewModel)
		{
            this.viewModel = viewModel;
		}

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SignUp(); 
        }
    }
}