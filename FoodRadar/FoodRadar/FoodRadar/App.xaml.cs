﻿using FoodRadar.DB;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FoodRadar
{
    public partial class App : Application
    {


        static FoodRadarDB database;
        public App()
        {
            InitializeComponent();

            // MainPage = new NavigationPage(new MainPage());
            Application.Current.MainPage = new MainPage();
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
