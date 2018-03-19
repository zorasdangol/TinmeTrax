using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp1.Logic;
using XamarinApp1.Models;
using XamarinApp1.ViewModels;

namespace XamarinApp1.UserInterfaces
{
   
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : MasterDetailPage
	{
        public HomePageVM HomePageVM { get; set; }
        public HomePage ()
		{
			InitializeComponent ();
            
            Detail = new NavigationPage(new DateSelectionPage());
            HomePageVM = new HomePageVM();
            BindingContext = HomePageVM;

        }

        private void OnMenuListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

                var selectedItem = (MenuItems)e.SelectedItem;
                var ind = selectedItem.Index;

                switch (ind)
                {
                    case 1:
                        Detail = new NavigationPage(new DateSelectionPage());
                        break;
                    case 2:
                        Detail = new NavigationPage(new LeavePage());
                        break;
                    case 3:
                        Detail = new NavigationPage(new LeaveSummaryPage());
                        break;
                    case 4:
                        Detail = new NavigationPage(new APISetPage());
                        break;
                    case 5:
                        conn.Execute("Delete from User");
                        conn.Close();
                        App.Current.MainPage = new NavigationPage(new MainPage());
                        break;                   
                    case 6:
                        Detail = new NavigationPage(new AboutUsPage());
                        break;
                }
                IsPresented = false;
            }catch(Exception ex) { DisplayAlert("Error",ex.Message,"OK"); }           
        }
    }
}