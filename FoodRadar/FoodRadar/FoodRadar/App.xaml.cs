    
﻿using FoodRadar.DB;
using System.IO;
﻿using App;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodRadar.Database.DatabaseModels;
using PageNavSingleton;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FoodRadar
{
    public partial class App : Application
    {
        static FoodRadarDB database;
        public App()
        {
            InitializeComponent();
            App.Database.resetDatabase();
            MainPage = new Intro();
            loadDataInDb();
        }

        private void loadDataInDb()
        {
            
            var res = new Restaurant()
            {
                name = "Bean",
                price = 2,
                desc = "lovely local small cafe/bar",
                address = "181 George St, Laneway Basement, Brisbane City QLD 4000",
                lon = -27.473210,
                lat = 153.025800,
                url = "https://beanbrisbane.com.au/",
                rating = 3
            };
            App.Database.SaveItemAsync(res);

            Cuisine c = new Cuisine()
            {
                name = "Italian",
            };
            App.Database.SaveItemAsync(c);


            Meal m = new Meal()
            {
                name = "Pizza",
                rating = 3,
                price = 25,
                cuisineId = App.Database.GetCuisineId("Italian"),
                restaurantId = App.Database.GetRestaurantId("Bean")
            };
            App.Database.SaveItemAsync(m);


            var res2 = new Restaurant()
            {
                name = "Hidden Bean",
                price = 3,
                desc = "not so lovely local small cafe/bar",
                address = "Some other street, Laneway Basement, Brisbane City QLD 4000",
                lon = -24.473210,
                lat = 152.025800,
                url = "https://beanbrisbane.com.au/",
                rating = 2
            };
            App.Database.SaveItemAsync(res2);

            var cust = new Customer()
            {
                email = "a",
                password = "a",
                firstName = "Siggi",
                lastName = "Jonsson"
            };
            App.Database.SaveItemAsync(cust);
        }

        public static FoodRadarDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new FoodRadarDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FoodRadarDB.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
