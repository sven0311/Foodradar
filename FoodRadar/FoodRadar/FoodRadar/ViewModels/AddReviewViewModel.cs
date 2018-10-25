using Acr.UserDialogs;
using FoodRadar.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodRadar.ViewModels
{
    public class AddReviewViewModel : ViewModelBase
    {
        public Meal m { get; set; }
        private int rating = 0;
        public Command Button_Rate { protected set; get; }
        public Command Button_star1 { protected set; get; }
        public Command Button_star2 { protected set; get; }
        public Command Button_star3 { protected set; get; }
        public Command Button_star4 { protected set; get; }
        public Command Button_star5 { protected set; get; }


        public AddReviewViewModel()
        {
            Button_Rate = new Command(() =>
            {
                addRatingToDatabase();
            });

            Button_star1 = new Command(() =>
            {
                rating = 1;
            });
            Button_star1 = new Command(() =>
            {
                rating = 2;
            });
            Button_star1 = new Command(() =>
            {
                rating = 3;
            });
            Button_star1 = new Command(() =>
            {
                rating = 4;
            });
            Button_star1 = new Command(() =>
            {
                rating = 5;
            });
        }

        private void addRatingToDatabase()
        {
            if (rating == 0)
            {
                UserDialogs.Instance.Alert("Please select a star rating.");
            } else {
                if (!LoginViewModel.loggedIn)
                {
                    UserDialogs.Instance.Alert("You can not rate if you are not logged in.", "Login required", "Ok");
                } else {
                    Rating ra = new Rating()
                    {
                        customerId = LoginViewModel.customer.Id,
                        mealId = m.Id,
                        desc = desc,
                        rate = rating
                    };
                    App.Database.SaveRating(ra);
                }
            }
        }

        public String Rest
        {
            get
            {
                return "Restaurant: " + App.Database.getRestaurantById(m.restaurantId).name;
            }
        }

        public String MealName
        {
            get
            {
                return "Meal: " + m.name;
            }
        }

        public String desc;
        public String Desc
        {
            get
            {
                return desc;
            }
            set
            {
                if (value != desc)
                {
                    desc = value;
                    OnPropertyChanged();
                }
            }
        }
        
    }
}
