using Foodradar.Views.Cells;
using FoodRadar.Database.DatabaseModels;
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
	public partial class RestaurantPage : ContentPage
	{
		public RestaurantPage ()
		{
			InitializeComponent ();
		}


        public async void CreatePage()
        {
            var stack = new StackLayout();
            var listView = new ListView();
            List<Meal> restaurants = App.Database.GetMeals().Result;
            listView.ItemsSource = restaurants;
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));

            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }
    }
}