using Acr.UserDialogs;
using FoodRadar.Database.DatabaseModels;
using PageNavSingleton;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace FoodRadar.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        public Command Button_ok { protected set; get; }
        private PageNavigationManager navManager;


        public SignUpViewModel()
        {
            navManager = PageNavigationManager.Instance;

            Button_ok = new Command(async () => test());
        }

        public async void test()
        {

            const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            //minimum 5 character, 1 letter & one number
            const string pwRegex = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}$";
            Customer x = await App.Database.CheckEmail(this.email);

            if (x != null)
            {
                UserDialogs.Instance.Alert("Please try another email", "Email already signed up", "Try again");
            }
            else if (this.FirstName == null || this.LastName == null)
            {
                UserDialogs.Instance.Alert("Name not Valid", "Please enter both your Last Name and First Name", "Try again");
            }
            else if (this.confirmPassword != this.password)
            {
                UserDialogs.Instance.Alert("", "Password Confirmation Fail", "Try again");
            }
            else if (!Regex.IsMatch(this.email, emailRegex))
            {
                UserDialogs.Instance.Alert("", "Email not valid", "Try again");
            }
            else if (!Regex.IsMatch(this.password, pwRegex))
            {
                UserDialogs.Instance.Alert("", "Password not valid, please chose another password", "Try again");
            }

            else
            {
                //create new costumer
                x = new Customer
                {
                    lastName = this.lastName,
                    firstName = this.firstName,
                    password = this.password,
                    email = this.email,
                };

                await App.Database.SaveItemAsync(x);

                LoginViewModel.customer = x;
                LoginViewModel.loggedIn = true;

                UserDialogs.Instance.Alert("Sign up complete!", "", "Go Browse");
                navManager.showMainPageAfterLoginPage();
                
            }
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
