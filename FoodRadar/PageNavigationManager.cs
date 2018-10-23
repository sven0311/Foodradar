using System;
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

        public INavigation Navigation
        {
            set { navigation = value; }
        }
        {
            navigation.PushAsync(new SignUpPage());
        }
    }
}