﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using FoodRadar.Database.DatabaseModels;


namespace FoodRadar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        public MapPage()
		{




            // var map = new Map(
            //MapSpan.FromCenterAndRadius(
            //        new Position(37, -122), Distance.FromMiles(0.3)))
            // {
            //     IsShowingUser = true,
            //     HeightRequest = 100,
            //     WidthRequest = 960,
            //     VerticalOptions = LayoutOptions.FillAndExpand
            // };
            // var stack = new StackLayout { Spacing = 0 };
            // stack.Children.Add(map);
            // Content = stack;

            InitializeComponent();
            //Commented out to remove button
            //btnGetLocation.Clicked += BtnGetLocation_Clicked;
            setPins();
            //await RetreiveLocation();
        }

        /*
        private async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {
           // await RetreiveLocation();
        }
        */
        private async void setPins()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync();

            var pos2 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = position.Longitude,
                Longitude = position.Latitude
            };

            setPinsOnMap(App.Database.GetRestaurants().Result, pos2);
        }

        private async void setPinsOnMap(List<Restaurant> rest, Xamarin.Forms.Labs.Services.Geolocation.Position pos2)
        {

            foreach (Restaurant r in rest)
            {
                var position = new Position(r.lat, r.lon);

                var pos1 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
                {
                    Latitude = r.lat,
                    Longitude = r.lon
                };
               

                var distance = Xamarin.Forms.Labs.Services.Geolocation.PositionExtensions.DistanceFrom(pos1, pos2);

                //maybe adjust 1000
                //if (distance > 1000)
                //    continue;

                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = r.name,
                    Address = r.address
                };
                MyMap.Pins.Add(pin);
                
            }
        }



    }
}