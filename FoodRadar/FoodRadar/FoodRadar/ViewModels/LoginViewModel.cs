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


namespace FoodRadar.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public bool loggedIn = false;
        public Customer customer = null;
        public Command Button_Clicked { protected set; get; }
        public Command Button_LogIn { protected set; get; }

        public LoginViewModel()
        {
            Button_Clicked = new Command(() =>
            {
                Application.Current.MainPage = new MainPage();
            });

            Button_LogIn = new Command(() =>
            {
                // await Navigation.PushAsync(new Profile());
                List<Customer> customers = App.Database.GetCustomersAsync().Result;
                Customer cust = App.Database.getPassword(email);
                if (cust == null)
                {
                    //pop up message (email not found)
                }
                if (cust.password == password)
                {
                    loggedIn = true;
                    customer = cust;
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
