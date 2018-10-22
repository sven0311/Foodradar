using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodRadar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{
		public Profile ()
		{
			InitializeComponent();
        }

        private async void Button_Details(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new ProfileDetailPage();
            await Navigation.PushAsync(new ProfileDetailPage());
        }

        private async void Button_Preferences(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new ProfileDetailPage();
            await Navigation.PushAsync(new ProfilePreferencesPage());
        }

        private async void Button_Ratings(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new ProfileDetailPage();
            await Navigation.PushAsync(new ProfileRatingsPage());
        }

    }


}