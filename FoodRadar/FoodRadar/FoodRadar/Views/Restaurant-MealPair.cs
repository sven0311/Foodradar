using FoodRadar.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.Views
{

    


    public class Restaurant_MealPair
    {
        public RestaurantListView rest { get; set; }
        public Meal meal { get; set; }

        Restaurant_MealPair() { }

        Restaurant_MealPair(Meal meal, RestaurantListView rest)
        {
            this.meal = meal;
            this.rest = rest;
        }

    }
}
