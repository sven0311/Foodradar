using FoodRadar.Database.DatabaseModels;
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
        public MainPage()
        {
            this.BarBackgroundColor = Color.FromHex("#e21f4f");
            var navigationPage = new NavigationPage(new Profile());
            navigationPage.Icon = "round_person_white_24dp.png";
            navigationPage.Title = "Profile";

            navigationPage.BarBackgroundColor = Color.FromHex("#e21f4f");
            

            Children.Add(new Search());
            Children.Add(new MapPage());
            Children.Add(navigationPage);
            
            //InitializeComponent();
            loadDataInDb();
            var pages = Children.GetEnumerator();
            pages.MoveNext(); // First page
            pages.MoveNext(); // Second page
            CurrentPage = pages.Current;
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
            App.Database.SaveRestaurant(res);
        }
    }

    
}
