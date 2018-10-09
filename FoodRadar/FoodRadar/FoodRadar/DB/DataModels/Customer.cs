using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.DB.DataModels
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        //add picture later

        public Customer() {
            ID = 0;
        }
        
    }
}
