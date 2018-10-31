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
            //navigation.PopAsync();
            navigation.PushAsync(new RestaurantPage(rest));
        }



        public void popPageAsync()
        {
            navigation.PopAsync();
        }

        //public void popModalAsync()
        //{
        //    navigation.PopModalAsync();
        //}

        public void showSignUpPage()
        {
            navigation.PushAsync(new SignUpPage());
        }

        public void showMainPageAfterLoginPage()
        {
            navigation.PopToRootAsync();
            navigation.PushAsync(new MainPage());
        }

        public void showProfileDetails()
        {
            navigation.PushAsync(new ProfileDetailPage());
        }

        public void showProfilePreferences()
        {
            navigation.PushAsync(new ProfilePreferencesPage());
        }

        public void showProfileRatings()
        {
            navigation.PushAsync(new ProfileRatingsPage());

        }

        public void showAddReviewPage(Meal meal)
        {
            m = meal;
            navigation.PushAsync(new AddReviewPage2());
        }

        public Meal m {get; set; }
    }
}