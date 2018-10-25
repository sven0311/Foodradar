using FoodRadar.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.Views
{
    public class RestaurantListView
    {
        public RestaurantListView(string name, int rating, int price, int id)
        {
            this.id = id;
            this.name = name;
            string tmpString = "";

            for (int i = 0; i < price; i++) tmpString += "$";
            this.price = tmpString;
            tmpString = "";

            for (int i = 0; i < rating; i++) tmpString += "*";
            this.rating = tmpString;
        }

        public RestaurantListView(Restaurant rest)
        {
            id = rest.Id;
            this.name = rest.name;
            string tmpString = "";

            for (int i = 0; i < rest.price; i++) tmpString += "$";
            this.price = tmpString;
            tmpString = "";

            for (int i = 0; i < rest.rating; i++) tmpString += "*";
            this.rating = tmpString;

            

        }

        public int id { get; set; }

        public string name { get; set; }
        public string rating { get; set; }
        public string price { get; set; }
    }
}
