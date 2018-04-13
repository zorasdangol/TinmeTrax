using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamarinApp1.ViewModels;

namespace XamarinApp1.Commands
{
    public class MasterHomePageCommand : ICommand
    {
        public MasterHomePageVM viewModel { get; set; }
        public MasterHomePageCommand(MasterHomePageVM viewModel)
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
            int index = Convert.ToInt32(parameter);
            viewModel.NavigateTo(index);
        }
    }
}
