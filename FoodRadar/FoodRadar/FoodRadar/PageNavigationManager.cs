using FoodRadar;
using System;
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

        public void showSignUpPage()
        {
            navigation.PushAsync(new SignUpPage());
        }
    }
}