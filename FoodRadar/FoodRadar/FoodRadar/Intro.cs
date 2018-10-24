using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection.Emit;
using Xamarin.Forms;
using FoodRadar.ViewModels;
using FoodRadar;
using PageNavSingleton;

namespace App
{
    public class Intro : ContentPage
    {
        Image logo;

        public Intro()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            logo = new Image
            {
                Source = "logo.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(logo, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(logo, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(logo);

            this.BackgroundColor = Color.FromHex("#F9F8F9");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await logo.ScaleTo(3, 2000);
            await logo.RotateTo(360, 1000);
            //await logo.ScaleTo(0.9, 1500, Easing.Linear);
            //await logo.ScaleTo(150, 1200, Easing.Linear);
            if (LoginViewModel.loggedIn)
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {

                Application.Current.MainPage = new NavigationPage(new FoodRadar.LogInpage(false));
            }
            PageNavigationManager.Instance.Navigation = Application.Current.MainPage.Navigation;
        }



    }
}
