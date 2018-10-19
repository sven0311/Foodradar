using System;
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
            btnGetLocation.Clicked += BtnGetLocation_Clicked;

            //await RetreiveLocation();
        }

        private async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {
            await RetreiveLocation();
        }

        private void setPins()
        {
            //App.Database
        }

        private void setPinsOnMap(Restaurant[] rest)
        {
            foreach (Restaurant r in rest)
            {
               
                lo

                var position = new Position(r.lat, r.lon);
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

        private async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            
            var position = await locator.GetPositionAsync();

            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                Distance.FromMiles(1)));    
        }

    }
}