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
    public partial class SearchResults : ContentPage
    {
        public List<Restaurant> restaurants;

        public SearchResults()
        {
            InitializeComponent();
            CreateList();

        }

        public List<RestaurantListView> listifyRestaurants(List<Restaurant> restaurants)
        {
            List<RestaurantListView> returnList = new List<RestaurantListView>();
            foreach(var r in restaurants)
            {
                returnList.Add(new RestaurantListView(r.name, r.rating, r.price));
            }

            return returnList;
        }


        public async void CreateList()
        {
            var listView = new ListView();
            List<RestaurantListView> restaurants = listifyRestaurants(App.Database.GetRestaurants().Result);
            listView.ItemsSource = restaurants;
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));

            listView.ItemTapped += async (sender, e) => {
                await DisplayAlert("Tapped", e.Item + " row was tapped", "OK");
                ((ListView)sender).SelectedItem = null; // de-select the row
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }
        

        public SearchResults(List<Restaurant> rst)
        {
            restaurants = rst;
            InitializeComponent();
        }

        public List<Restaurant> getRestaurants
        {
            get
            {
                return restaurants;
            }
        }

	}
}