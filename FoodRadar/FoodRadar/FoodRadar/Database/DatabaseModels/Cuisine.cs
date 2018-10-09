using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace FoodRadar.Database.DatabaseModels
{
    class Cuisine
    {

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string name { get; set; }
    }
}
