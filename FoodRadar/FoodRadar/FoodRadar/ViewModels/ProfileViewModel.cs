using FoodRadar.Database.DatabaseModels;
using FoodRadar.DB;
using PageNavSingleton;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodRadar.ViewModels
{
    
    public class ProfileViewModel : ViewModelBase
    {
        //pageNavManager
        private PageNavigationManager navManager;

        public Command Button_Details { protected set; get; }
        public Command Button_Preferences { protected set; get; }
        public Command Button_Ratings { protected set; get; }


        public ProfileViewModel()
        {
            navManager = PageNavigationManager.Instance;

            Button_Details = new Command(() =>
            {
                navManager.showProfileDetails();
            });

            Button_Preferences = new Command(() =>
            {
                navManager.showProfilePreferences();
            });

            Button_Ratings = new Command(() =>
            {
                navManager.showProfileRatings();
            });
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
