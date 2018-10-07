using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace FoodRadar.Database.DatabaseModels
{
    class Restaurant
    {

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string name { get; set; }

        [Column("Description")]
        public string desc { get; set; }

        [Column("lat")]
        public float lat { get; set; }

        [Column("lon")]
        public float lon { get; set; }

        [Column("Address")]
        public string address { get; set; }

        //add picture later

        [Column("Price")] //check price > 0 && price < 5
        public int price { get; set; }

        [Column("OpeningHours")]
        public string openingHours { get; set; }

        [Column("URL")]
        public string url { get; set; }


    }
}
