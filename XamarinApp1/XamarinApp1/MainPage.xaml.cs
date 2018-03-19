using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinApp1.UserInterfaces;
using XamarinApp1.ViewModels;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //try
            //{
            //    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            //    if(status != PermissionStatus.Granted)
            //    {
            //        if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
            //        {
            //            await DisplayAlert("Need Permission", "We will have to access your Location", "OK");
            //        }

            //        var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

            //        if (results.ContainsKey(Permission.Location))
            //            status = results[Permission.Location];                    
            //    }
            //    if(status == PermissionStatus.Granted)
            //    {
            //        await DisplayAlert("Granted","Access granted", "OK");
            //    }
            //    else
            //    {
            //        await DisplayAlert("No permission", "You didn't granted location permission","ok");
            //    }
            //}catch(Exception ex) {       }
        }

    }
}
