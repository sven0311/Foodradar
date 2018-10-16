using FoodRadar.DB;
using FoodRadar.DB.DataModels;
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
            customer.FirstName = "Sigurdur";
            customer.LastName = "Jonsson";
            App.Database.SaveItemAsync(customer);
        }

        public string GetFirstName
        {
            
            get
            {
                List<Customer> customers = App.Database.GetItemsAsync().Result;
                return customers[0].FirstName; }
        }

        public string GetLastName
        {

            get
            {
                List<Customer> customers = App.Database.GetItemsAsync().Result;
                return customers[0].LastName;
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
