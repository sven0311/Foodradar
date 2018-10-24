using Foodradar.Views.Cells;
using FoodRadar.Database.DatabaseModels;
using FoodRadar.Views;
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

        RestaurantListView restaurant; 
		public RestaurantPage (RestaurantListView restaurant)
		{
			InitializeComponent ();
            this.restaurant = restaurant;
            CreatePage();
		}


        public async void CreatePage()
        {
            

            var restaurantName = new Label
            {
                Text = restaurant.name,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var restaurantPrice = new Label
            {
                Text = restaurant.price,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var restaurantRating = new Label
            {
                Text = restaurant.rating,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };


            var firstStack = new StackLayout()
            {
                Children = { restaurantName, restaurantPrice, restaurantRating },
            };


            var listView = new ListView();
            List<Meal> restaurants = App.Database.GetMeals().Result;
            listView.ItemsSource = restaurants;
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));

            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            var parentStack = new StackLayout()
            {
                Children = {firstStack, listView}
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = parentStack;
        }
    }
}