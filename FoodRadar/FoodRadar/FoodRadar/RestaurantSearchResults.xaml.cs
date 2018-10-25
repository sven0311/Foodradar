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
    public partial class RestaurantSearchResults : ContentPage
    {
        public List<Restaurant> restaurants;

        public RestaurantSearchResults()
        {
            InitializeComponent();
            CreateList();

        }

        public List<RestaurantListView> listifyRestaurants(List<Restaurant> restaurants)
        {
            List<RestaurantListView> returnList = new List<RestaurantListView>();
            foreach(var r in restaurants)
            {
                returnList.Add(new RestaurantListView(r));
            }

            return returnList;
        }


        public void CreateList()
        {
            var listView = new ListView();
            List<RestaurantListView> restaurants = listifyRestaurants(App.Database.GetRestaurants().Result);
            listView.ItemsSource = restaurants;
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));

            
            listView.ItemTapped += async (sender, e) => {
                
                Application.Current.MainPage = new RestaurantPage((RestaurantListView) e.Item);
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }
        

        public RestaurantSearchResults(List<Restaurant> rst)
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