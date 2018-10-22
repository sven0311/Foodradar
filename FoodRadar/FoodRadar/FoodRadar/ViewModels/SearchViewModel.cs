using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodRadar.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
            Search_Clicked = new Command(() =>
            {
                Application.Current.MainPage = new SearchResults();
            });
        }


        public Command Search_Clicked { protected set; get; }
        public int distance = 100;
        public int price = 25;
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
