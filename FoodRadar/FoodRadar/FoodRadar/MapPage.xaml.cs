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
using FoodRadar.DB;

namespace FoodRadar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            setPins();
        }

        private async void setPins()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;

            //var position = await locator.GetPositionAsync();


            //MyMap.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), new Distance(500)));
            MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(new Position(-27.482276, 153.021552), new Distance(500)));

            var pos2 = new Xamarin.Forms.Labs.Services.Geolocation.Position()
            {
                //Latitude = position.Longitude,
                //Longitude = position.Latitude
                Latitude = -27.482276,
                Longitude = 153.021552
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
                var dist = FoodRadarDB.CalculateDistance(pos1, pos2);
                //maybe adjust 1000
                if (dist > 500)
                    continue;

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