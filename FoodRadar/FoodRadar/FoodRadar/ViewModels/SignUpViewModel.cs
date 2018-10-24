using Acr.UserDialogs;
using FoodRadar.Database.DatabaseModels;
using PageNavSingleton;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodRadar.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        public Command Button_ok { protected set; get; }

        public SignUpViewModel()
        {

            Button_ok = new Command(async () =>
            {
                Customer x = await App.Database.CheckEmail(email);

                if (x != null)
                {
                    UserDialogs.Instance.Alert("Please try another email", "Email already signed up", "Try again");
                }
                else if (confirmPassword != password)
                {
                    UserDialogs.Instance.Alert("", "Password Confirmation Fail", "Try again");
                }
                else
                {
                    //create new costumer
                    x = new Customer
                    {
                        lastName = lastName,
                        firstName = firstName,
                        password = password,
                        email = email,
                    };

                    await App.Database.SaveCustomerAsync(x);

                    LoginViewModel.customer = x;
                    LoginViewModel.loggedIn = true;

                    UserDialogs.Instance.Alert("Sign up complete!");

                    Application.Current.MainPage = new MainPage();

                }
            });
        }


        public String email;
        public String Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
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
                    firstName = value;
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
                    lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        public String confirmPassword;
        public String ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                if (confirmPassword != value)
                {
                    confirmPassword = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
