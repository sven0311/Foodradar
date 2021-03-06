﻿using FoodRadar.Database.DatabaseModels;
using FoodRadar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodRadar
{
    public partial class MainPage : TabbedPage
    {

        NavigationPage navigationPage;
        public MainPage()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.FromHex("#e21f4f");
            


            Children.Add(new Search());
            Children.Add(new MapPage());
            if (LoginViewModel.loggedIn)
            {
                navigationPage = new NavigationPage(new Profile());
                navigationPage.Icon = "round_person_white_24dp.png";
                navigationPage.Title = "Profile";

                navigationPage.BarBackgroundColor = Color.FromHex("#e21f4f");
                Children.Add(navigationPage);

            }
            else
            {
                //navigationPage =  new NavigationPage(new LogInpage(true));
                Children.Add(new LogInpage(true));
            }


            var pages = Children.GetEnumerator();
            pages.MoveNext(); // First page
            pages.MoveNext(); // Second page
            if (App.LoginStatus == 1)
            {
                pages.MoveNext();
                App.LoginStatus = 0;
            }
            if (App.LoginStatus == 0)
                App.LoginStatus = 1;
            CurrentPage = pages.Current;
        }

        public void replaceLoginTabWithProfileTab()
        {
            Children.Remove(navigationPage);
            navigationPage = new NavigationPage(new Profile());
            navigationPage.Icon = "round_person_white_24dp.png";
            navigationPage.Title = "Profile";

            navigationPage.BarBackgroundColor = Color.FromHex("#e21f4f");
            Children.Add(navigationPage);
        }
    }

    
}
