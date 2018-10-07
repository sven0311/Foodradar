using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace FoodRadar.Database.DatabaseModels
{
    [Table("Customers")]
    class Customer
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [Column("FirstName")]
        public string firstName { get; set; }

        [Column("LastName")]
        public string lastName { get; set; }

        //add profile picture to model
    }
}
