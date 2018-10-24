using FoodRadar.Database.DatabaseModels;
using FoodRadar.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.ViewModels
{
    
    public class ProfileViewModel : ViewModelBase
    {
       
        public ProfileViewModel()
        {
        }

        public string GetFirstName
        {
            
            get
            {
                return LoginViewModel.customer.firstName;
            }
        }

        public string GetLastName
        {

            get
            {
                return LoginViewModel.customer.lastName;
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
