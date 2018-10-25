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

        Xamarin.Forms.Labs.Services.Geolocation.Position userPos = new Xamarin.Forms.Labs.Services.Geolocation.Position();
        public MapPage()
        {
            InitializeComponent();
            setPins();
        }

        public async void setLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            var position = await locator.GetPositionAsync();
            userPos.Latitude = position.Latitude;
            userPos.Longitude = position.Longitude;
        }

        private async void setPins()
        {

            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(userPos.Latitude, userPos.Longitude), new Distance(500)));

            var pos2 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                Latitude = userPos.Longitude,
                Longitude = userPos.Latitude
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