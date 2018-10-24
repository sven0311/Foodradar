using System;
using System.Collections.Generic;
using System.Text;
using System;
using App;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodRadar.Database.DatabaseModels;
using PageNavSingleton;
using Acr.UserDialogs;

namespace FoodRadar.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //pageNavManager
        private PageNavigationManager navManager;

        //vars to check if user loged in and to get logged in user
        public static Customer customer = null;
        public static bool loggedIn = false;

        public Command Button_Clicked { protected set; get; }
        public Command Button_SignUp { protected set; get; }
        public Command Button_LogIn { protected set; get; }

        public LoginViewModel()
        {
            navManager = PageNavigationManager.Instance;

            Button_Clicked = new Command(() =>
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
                PageNavigationManager.Instance.Navigation = Application.Current.MainPage.Navigation;
            });

            Button_SignUp = new Command(() =>
            {
                //Application.Current.MainPage = new MainPage();
                navManager.showSignUpPage();
            });

            Button_LogIn = new Command(() =>
            {

                // await Navigation.PushAsync(new Profile());
                if (email == null || password == null || email.Equals("") || password.Equals(""))
                {
                    UserDialogs.Instance.Alert("Email and password field can not be blank");
                }
                else
                {
                    Customer cust = App.Database.getPassword(email);
                    if (cust == null)
                    {
                        UserDialogs.Instance.Alert("Wrong email");

                    }
                    else { 
                        if (cust.password == password)
                        {
                            loggedIn = true;
                            customer = cust;
                            Application.Current.MainPage = new MainPage();
                            PageNavigationManager.Instance.Navigation = Application.Current.MainPage.Navigation;
                        }
                        else
                        {
                            UserDialogs.Instance.Alert("Wrong password");
                        }
                    }
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

        public String password;
        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                if(value != password)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
