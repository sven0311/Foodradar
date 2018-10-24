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
                return FoodRadar.ViewModels.LoginViewModel.customer.email;
            }
        }
        
        public String FirstName
        {
            get
            {
                return FoodRadar.ViewModels.LoginViewModel.customer.firstName;
            }
        }
        
        public String LastName
        {
            get
            {
                return FoodRadar.ViewModels.LoginViewModel.customer.lastName;
            }
        }
    }
}
