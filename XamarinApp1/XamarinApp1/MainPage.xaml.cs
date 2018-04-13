using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp1.UserInterfaces;
using XamarinApp1.ViewModels;
using XamarinApp1.Models;

namespace XamarinApp1
{
	public partial class MainPage : ContentPage
	{
        public MainPageVM mainPageVM;
		public MainPage()
		{
			InitializeComponent();
            mainPageVM = new MainPageVM();
            BindingContext = mainPageVM;
		}        
        
    }
}
