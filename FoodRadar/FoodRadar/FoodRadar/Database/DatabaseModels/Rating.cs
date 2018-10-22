using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace FoodRadar.Database.DatabaseModels
{
    public class Rating
    {

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [NotNull, Column("Rating")] //check rate > 0 && rate < 6
        public int rate { get; set; }

        [Column("Description")]
        public string desc { get; set; }

        //add picture later

        [NotNull, Column("MealId")]
        public int mealId { get; set; }

        [NotNull, Column("CustomerId")]
        public int customerId { get; set; }

    }
}
