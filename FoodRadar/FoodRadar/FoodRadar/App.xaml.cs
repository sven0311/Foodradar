
﻿using FoodRadar.DB;
using System.IO;
﻿using App;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodRadar.Database.DatabaseModels;
using PageNavSingleton;
using System.Linq;

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
                lat = -27.473210,
                lon = 153.025800,
                url = "https://beanbrisbane.com.au/"
            };
            App.Database.SaveRestaurant(res);

            var cust1 = new Customer()
            {
                email = "a",
                password = "a",
                firstName = "Siggi",
                lastName = "Jonsson",
            };
            App.Database.SaveCustomerAsync(cust1);

            var cust2 = new Customer()
            {
                email = "s",
                password = "s",
                firstName = "Sven",
                lastName = "Andabaka"
            };
            App.Database.SaveCustomerAsync(cust2);

            var meal1 = new Meal()
            {
                name = "Schnitzel",
                restaurantId = App.Database.GetRestaurants().Result.First().Id,
            };
            App.Database.SaveMealAsync(meal1);

            int mealId = App.Database.getMeal().Result.First().Id;
            int cust1ID = App.Database.getPassword("a").Id;
            var rating1 = new Rating()
            {
                customerId = cust1ID,
                desc = "schlechtes Schnitzel",
                rate = 1,
                mealId = mealId,
            };
            App.Database.SaveRating(rating1);

            var rating2 = new Rating()
            {
                customerId = cust1ID,
                desc = "gutes Schnitzel",
                rate = 5,
                mealId = mealId,
            };
            App.Database.SaveRating(rating2);

            var rating3 = new Rating()
            {
                customerId = cust1ID,
                desc = "geht so Schnitzel",
                rate = 3,
                mealId = mealId,
            };
            App.Database.SaveRating(rating3);

            
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
