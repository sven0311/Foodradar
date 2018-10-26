using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.ViewModels
{
    class ProfileDetailViewModel : ViewModelBase
    {
        
        public String Email
        {
            get
            {
                return "Email: " + FoodRadar.ViewModels.LoginViewModel.customer.email;
            }
        }
        
        public String FirstName
        {
            get
            {
                return "First Name: " + FoodRadar.ViewModels.LoginViewModel.customer.firstName;
            }
        }
        
        public String LastName
        {
            get
            {
                return "Last Name: " + FoodRadar.ViewModels.LoginViewModel.customer.lastName;
            }
        }
    }
}
