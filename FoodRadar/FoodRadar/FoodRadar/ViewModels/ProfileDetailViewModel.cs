using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.ViewModels
{
    class ProfileDetailViewModel : ViewModelBase
    {


        public String email;
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                email = FoodRadar.ViewModels.LoginViewModel.customer.email;
                OnPropertyChanged();
            }
        }

        public String firstName;
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (firstName != value)
                {
                    firstName = FoodRadar.ViewModels.LoginViewModel.customer.firstName;
                    OnPropertyChanged();
                }
            }
        }

        public String lastName;
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (lastName != value)
                {
                    lastName = FoodRadar.ViewModels.LoginViewModel.customer.lastName;
                    OnPropertyChanged();
                }
            }
        }
    }
}
