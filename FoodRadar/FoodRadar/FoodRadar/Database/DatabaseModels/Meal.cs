using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;


namespace FoodRadar.Database.DatabaseModels
{
    public class Meal
    {

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string name { get; set; }

        [NotNull, Column("CuisineId")]
        public Cuisine cuisine { get; set; }

        [NotNull, Column("RestaurantId")]
        public Restaurant restaurant { get; set; }
    }
}
