﻿using Acr.UserDialogs;
using FoodRadar.Database.DatabaseModels;
using PageNavSingleton;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodRadar.ViewModels
{
    public class AddReviewViewModel : ViewModelBase
    {
        string RestaurantName;
        public Meal m { get; set; }
        private int rating = 0;
        public Command Button_Rate { protected set; get; }
        public Command Button_star1 { protected set; get; }
        public Command Button_star2 { protected set; get; }
        public Command Button_star3 { protected set; get; }
        public Command Button_star4 { protected set; get; }
        public Command Button_star5 { protected set; get; }
        private PageNavigationManager navManager = PageNavigationManager.Instance;


        public AddReviewViewModel()
        {
            m = navManager.m;
            RestaurantName = App.Database.getRestaurantById(m.restaurantId).name;
            Button_Rate = new Command(() =>
            {
                addRatingToDatabase();
            });

            Button_star1 = new Command(() =>
            {
                rating = 1;
                Stars = "Stars: " + rating;
            });
            Button_star2 = new Command(() =>
            {
                rating = 2;
                Stars = "Stars: " + rating;

            });
            Button_star3 = new Command(() =>
            {
                rating = 3;
                Stars = "Stars: " + rating;
            });
            Button_star4 = new Command(() =>
            {
                rating = 4;
                Stars = "Stars: " + rating;
            });
            Button_star5 = new Command(() =>
            {
                rating = 5;
                Stars = "Stars: " + rating;
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
                    App.LoginStatus = 2;
                    navManager.showLoginPageAfterAddReview();
                } else {
                    Rating ra = new Rating()
                    {
                        customerId = LoginViewModel.customer.Id,
                        mealId = m.Id,
                        desc = desc,
                        rate = rating
                    };
                    App.Database.SaveRating(ra);
                    navManager.popPageAsync();
                }
            }
        }

        public String Rest
        {
            get
            {
                String s = "Restaurant: " + RestaurantName;
                return s;
            }
        }

        private String stars = "Stars: ";
        public String Stars
        {
            get
            {
                return stars;
            }
            set
            {
                stars = value;
                OnPropertyChanged();
            }
        }

        public String MealName
        {
            get
            {
                String s = "Meal: " + m.name;

                return s;
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
