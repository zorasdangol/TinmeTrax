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

        public bool bExit = true;
        public HomePageVM HomePageVM { get; set; }
        public HomePage ()
		{
			InitializeComponent ();            
            HomePageVM = new HomePageVM();
            BindingContext = HomePageVM;
            Detail = new NavigationPage(new MasterHomePage());
            
        }

        public HomePage(int i)
        {
            InitializeComponent();
            HomePageVM = new HomePageVM();
            BindingContext = HomePageVM;
            Detail = new NavigationPage(new NoResponsePage());
        }

        private async void OnMenuListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

                var selectedItem = (MenuItems)e.SelectedItem;
                var ind = selectedItem.Index;
                bExit = true;

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
                        Detail = new NavigationPage(new ApiPasswordPage());
                        break;
                    case 5:
                        bool result =await  DisplayAlert("Confirm", "Are you sure to LogOut?", "OK", "Cancel") ;
                        if (result)
                        {
                            Helpers.Data.User = new User();
                            conn.Execute("Delete from User");
                            conn.Close();
                            App.Current.MainPage = new NavigationPage(new MainPage());
                        }                       
                        break;                   
                    case 6:
                        Detail = new NavigationPage(new AboutUsPage());
                        break;
                }
                IsPresented = false;
            }catch(Exception ex) { await DisplayAlert("Error",ex.Message,"OK"); }           
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    if (!bExit)
        //    {
        //        return base.OnBackButtonPressed();
        //    }
        //    Detail = new NavigationPage(new MasterHomePage());
        //    bExit = false;
        //    return true;
        //}
        protected override bool OnBackButtonPressed()
        {
            var obj = Detail.Navigation.NavigationStack;
            if (obj.Count > 1)
            {
                var detail = Detail as NavigationPage;
                detail.PopAsync();
                return true;
            }
            var currentPage = obj.LastOrDefault();
            if(currentPage.GetType() == typeof(MasterHomePage))
            {
                LogOutFunction();
                return bExit;
            }
            else
            {
                Detail = new NavigationPage(new MasterHomePage());
            }
            return true;
        }

        public async void LogOutFunction()
        {
            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

            bExit = await DisplayAlert("Confirmation", "Do you want to LogOut?", "No", "Yes");
            if (!bExit)
            {
                Helpers.Data.User = new User();
                conn.Execute("Delete from User");
                conn.Close();                
            }
        }

    }
}