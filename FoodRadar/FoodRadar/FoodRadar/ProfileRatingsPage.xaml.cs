using FoodRadar.Database.DatabaseModels;
using FoodRadar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FoodRadar.ViewModels.ProfileRatingViewModel;

namespace FoodRadar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileRatingsPage : ContentPage
	{
		public ProfileRatingsPage ()
		{
			InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#e21f4f");

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;

            if (e.SelectedItem != null)
            {

                await Navigation.PushAsync(new ProfileRatingDetailPage((ProfileRatingViewModel)e.SelectedItem));
            }

            //await Navigation.PushModalAsync(new ProfileRatingDetailPage((ListIt)e.SelectedItem));
        }


    }


}