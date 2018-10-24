using FoodRadar;
using FoodRadar.Database.DatabaseModels;
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
            navigation.PushModalAsync(new MealSearchResults(meals));
        }

        public void showSignUpPage()
        {
            navigation.PushAsync(new SignUpPage());
        }
    }
}