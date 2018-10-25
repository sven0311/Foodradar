    
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
            MainPage = new Intro();
         
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
