using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FoodRadar;
using PageNavSingleton;
using Plugin.Geolocator;

namespace FoodRadar.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {

        Xamarin.Forms.Labs.Services.Geolocation.Position userPos = new Xamarin.Forms.Labs.Services.Geolocation.Position();

        private PageNavigationManager navManager = PageNavigationManager.Instance;
        public SearchViewModel()
        {
            Search_Clicked = new Command(() => Search_Button());
            setLocation();
            
        }

        public async void setLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            //var position = await locator.GetPositionAsync();
            //userPos.Latitude = position.Latitude;
            //userPos.Longitude = position.Longitude;
            userPos.Longitude = 153.021552;
            userPos.Latitude = -27.482276;
        }

        public async void Search_Button()
        {
            navManager.showMealSearchResultsPage(App.Database.SearchMeals(searchString, userPos: userPos, distanceFilter: distance, priceFilter: price));
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
