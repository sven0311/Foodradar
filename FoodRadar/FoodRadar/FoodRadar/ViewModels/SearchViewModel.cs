using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
        }

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
