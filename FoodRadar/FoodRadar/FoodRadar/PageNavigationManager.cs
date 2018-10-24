using FoodRadar;
using FoodRadar.Database.DatabaseModels;
using FoodRadar.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PageNavSingleton
{
    public class PageNavigationManager
    {
        private static PageNavigationManager instance;
        private PageNavigationManager() { }
        public static PageNavigationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageNavigationManager();
                }
                return instance;
            }
        }

        private INavigation navigation;
        public INavigation Navigation
        {
            set { navigation = value; }
        }

        public void showMealSearchResultsPage(List<Meal> meals)
        {
            navigation.PushAsync(new MealSearchResults(meals));
        }

        public void showMealPage(MealListView meal)
        {
            navigation.PushAsync(new MealPage(meal));
        }

        public void showRestaurantPage(RestaurantListView rest)
        {
            navigation.PushAsync(new RestaurantPage(rest));
        }

        public void showSignUpPage()
        {
            navigation.PushAsync(new SignUpPage());
        }
    }
}