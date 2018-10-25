using Foodradar.Views.Cells;
using FoodRadar.Database.DatabaseModels;
using FoodRadar.Views;
using PageNavSingleton;
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

        private PageNavigationManager navManager = PageNavigationManager.Instance;

        RestaurantListView restaurant; 
		public RestaurantPage (RestaurantListView restaurant)
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#e21f4f");

            this.restaurant = restaurant;
            CreatePage();
		}

        public List<MealListView> listifyMeals(List<Meal> meals)
        {
            List<MealListView> returnList = new List<MealListView>();
            foreach (var r in meals)
            {
                returnList.Add(new MealListView(r.name, r.rating, r.price, r.restaurantId, r.Id));
            }

            return returnList;
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
                HorizontalOptions = LayoutOptions.Center,
                Children = { restaurantName, restaurantPrice, restaurantRating },
            };

            


            var listView = new ListView();
            List<MealListView> restaurants = listifyMeals(App.Database.GetMeals().Result);
            listView.ItemsSource = restaurants;
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));

            listView.ItemTapped += async (sender, e) => {
                navManager.showMealPage((MealListView)e.Item);
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