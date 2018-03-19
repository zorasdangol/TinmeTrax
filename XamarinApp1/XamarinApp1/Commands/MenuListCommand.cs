using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using XamarinApp1.Models;

namespace XamarinApp1.Commands
{
    public class MenuListCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MenuItems SelectedMenuItem = (MenuItems)parameter;
        }
    }
}
