using FoodRadar.Database.DatabaseModels;
using FoodRadar.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.ViewModels
{
    
    public class ProfileViewModel : ViewModelBase
    {
       
        public Customer customer = new Customer();

        public ProfileViewModel()
        {
            customer.firstName = "Sigurdur";
            customer.lastName = "Jonsson";
            App.Database.SaveItemAsync(customer);
        }

        public string GetFirstName
        {
            
            get
            {
                List<Customer> customers = App.Database.GetCustomersAsync().Result;
                return customers[0].firstName; }
        }

        public string GetLastName
        {

            get
            {
                List<Customer> customers = App.Database.GetCustomersAsync().Result;
                return customers[0].lastName;
            }
        }

        public string GetFullNameWithLineBreak
        {

            get
            {
                return GetFirstName + "\r\n" + GetLastName;
            }
        }
    }
}
