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
            //var l = App.Database.getRatings().Result;

            //listView.ItemsSource = buildList();
            //listView.ItemTapped += async (sender, e) => {

              //  await Navigation.PushModalAsync(new ProfileRatingDetailPage((ListIt)e.Item));
            //};
        }

        

        private async void Button_Back(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Profile();
            await Navigation.PopModalAsync();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;

            if (e.SelectedItem != null)
            {
           
                await Navigation.PushModalAsync(new ProfileRatingDetailPage((ProfileRatingViewModel) e.SelectedItem));
            }

            //await Navigation.PushModalAsync(new ProfileRatingDetailPage((ListIt)e.SelectedItem));
        }


    }


}