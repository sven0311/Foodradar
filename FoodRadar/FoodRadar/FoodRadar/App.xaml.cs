
﻿using FoodRadar.DB;
using System.IO;
﻿using App;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodRadar.Database.DatabaseModels;

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
                url = "https://beanbrisbane.com.au/"
            };

            var cust = new Customer()
            {
                email = "asdf@asdf.com",
                password = "12345",
                firstName = "Siggi",
                lastName = "Jonsson"
            };
            App.Database.SaveCustomerAsync(cust);
            App.Database.SaveRestaurant(res);
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
