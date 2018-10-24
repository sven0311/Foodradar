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
    public partial class MealSearchResults : ContentPage
    {
        private PageNavigationManager navManager = PageNavigationManager.Instance;
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

        public List<MealListView> listifyMeals(List<Meal> meals)
        {
            List<MealListView> returnList = new List<MealListView>();
            foreach (var r in meals)
            {
                returnList.Add(new MealListView(r.name, r.rating, r.price));
            }

            return returnList;
        }


        public void CreateList()
        {
            var listView = new ListView();

            listView.ItemsSource = listifyMeals(meals);
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));


            listView.ItemTapped += async (sender, e) => {
                Meal m = (Meal)e.Item;
                Restaurant r = App.Database.GetRestaurantById(m.restaurantId);
                RestaurantListView  rest = new RestaurantListView(r.name, r.rating, r.price);

                navManager.showRestaurantPage(rest);
                navManager.showMealPage(m);
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