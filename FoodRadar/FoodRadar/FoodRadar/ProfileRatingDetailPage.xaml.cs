﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodRadar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FoodRadar.ProfileRatingsPage;

namespace FoodRadar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileRatingDetailPage : ContentPage
    {
        public ProfileRatingDetailPage(ProfileRatingViewModel listIt)
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#e21f4f");

            buildPage(listIt);
        }

        private void buildPage(ProfileRatingViewModel listIt)
        {
            var restaurant = new Label
            {
                Text = "Restaurant: " + listIt.restaurantName,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                //FontAttributes = FontAttributes.Bold
            };

            var meal = new Label
            {
                Text = "Meal: " + listIt.mealName,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                //FontAttributes = FontAttributes.Bold
            };

            var rate = new Label
            {
                Text = "Rating: " + listIt.rating.rate,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                //FontAttributes = FontAttributes.Bold
            };

            var desc = new Label
            {
                Text = "Description: " + listIt.rating.desc,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                //FontAttributes = FontAttributes.Bold
            };

            var delete = new Button()
            {
                Text = "Delete Rating",

            };
            delete.Clicked += async (sender, args) =>
            {
                await App.Database.DeleteRatingAsync(listIt.rating);
                await Navigation.PopAsync();
            };

            var firstStack = new StackLayout()
            {
                Children = { restaurant, meal, rate, desc, delete },
                Margin = new Thickness(20, 15,40,15)
            };

            Content = firstStack;

        }
    }
}