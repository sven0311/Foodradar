﻿using Foodradar.Views.Cells;
using FoodRadar.Database.DatabaseModels;
using FoodRadar.Views;
using PageNavSingleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodRadar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestaurantPage : ContentPage
	{

        private PageNavigationManager navManager = PageNavigationManager.Instance;

        RestaurantListView restaurant; 
		public RestaurantPage (RestaurantListView restaurant)
		{
			InitializeComponent ();
            this.restaurant = restaurant;
            CreatePage();
		}


        public async void CreatePage()
        {
            

            var restaurantName = new Label
            {
                Text = restaurant.name,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var restaurantPrice = new Label
            {
                Text = restaurant.price,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var restaurantRating = new Label
            {
                Text = restaurant.rating,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };


            var firstStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Children = { restaurantName, restaurantPrice, restaurantRating },
            };


            var listView = new ListView();
            List<Meal> restaurants = App.Database.GetMeals().Result;
            listView.ItemsSource = restaurants;
            listView.ItemTemplate = new DataTemplate(typeof(RestaurantListCell));

            listView.ItemTapped += async (sender, e) => {
                navManager.showMealPage((Meal)e.Item);
            };

            var parentStack = new StackLayout()
            {
                Children = {firstStack, listView}
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = parentStack;
        }
    }
}