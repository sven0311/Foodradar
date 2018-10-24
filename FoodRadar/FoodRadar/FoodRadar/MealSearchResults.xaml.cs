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
    public partial class MealSearchResults : ContentPage
    {
        public List<Meal> meals;

        public MealSearchResults()
        {
            InitializeComponent();
            CreateList();
        }

        public MealSearchResults(List<Meal> mls)
        {
            InitializeComponent();
            meals = mls;
           
            CreateList();
        }

        public List<MealListView> listifyMeals(List<Restaurant> restaurants)
        {
            List<MealListView> returnList = new List<MealListView>();
            foreach (var r in restaurants)
            {
                returnList.Add(new MealListView(r.name, r.rating, r.price));
            }

            return returnList;
        }


        public void CreateList()
        {
            var listView = new ListView();

            listView.ItemsSource = meals;
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));


            listView.ItemTapped += async (sender, e) => {

                Application.Current.MainPage = new RestaurantPage((RestaurantListView)e.Item);
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = listView;
        }


        

        public List<Meal> getMeals
        {
            get
            {
                return meals;
            }
        }

    }
}