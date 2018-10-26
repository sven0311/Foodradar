using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.Views
{
    public class MealListView
    {
        public MealListView(string name, int rating, int price, int restId, int id)
        {
            this.id = id;
            this.restaurantId = restId;

            this.name = name;
            string tmpString = "";
            
            this.price = price + "$";
            

            for (int i = 0; i < rating; i++) tmpString += "*";
            this.rating = tmpString;
        }

        public int id { get; set; }
        public int restaurantId { get; set; }
        public string name { get; set; }
        public string rating { get; set; }
        public string price { get; set; }
    }
}
