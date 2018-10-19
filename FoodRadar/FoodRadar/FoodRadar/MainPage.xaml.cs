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
            InitializeComponent();
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
            App.Database.SaveRestaurant(res);
        }
    }

    
}
