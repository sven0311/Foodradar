using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRadar.ViewModels
{
    class ProfileDetailViewModel : ViewModelBase
    {


        public String email = "a";
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

        public String firstName = "Sven";
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
                    //firstName = FoodRadar.ViewModels.LoginViewModel.customer.firstName;
                    firstName = value;
                    OnPropertyChanged();
                }
            }
        }

        public String lastName = "Andabaka";
        public String LastName
        {
            get
            {
                return FoodRadar.ViewModels.LoginViewModel.customer.lastName;
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
