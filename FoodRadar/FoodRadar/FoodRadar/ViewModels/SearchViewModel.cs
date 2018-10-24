using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FoodRadar;
using PageNavSingleton;

namespace FoodRadar.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {

        private PageNavigationManager navManager = PageNavigationManager.Instance;
        public SearchViewModel()
        {
            Search_Clicked = new Command(() => Search_Button());
        }

        public void Search_Button()
        {
            navManager.showMealSearchResultsPage(App.Database.SearchMeals(searchString));
        }

        public Command Search_Clicked { protected set; get; }
        public int distance = 100;
        public int price = 25;
        public string searchString;

        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                if (searchString != value)
                {
                    searchString = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Distance
        {
            get
            {
                return distance;
            }
            set
            {
                if (distance != value)
                {
                    distance = value;
                    OnPropertyChanged();
                }
            }
        }


        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged();
                }
            }
        }

    }

}
