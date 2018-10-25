using FoodRadar.Database.DatabaseModels;
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
        public MainPage()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.FromHex("#e21f4f");
            


            Children.Add(new Search());
            Children.Add(new MapPage());
            if (LoginViewModel.loggedIn)
            {
                var navigationPage = new NavigationPage(new Profile());
                navigationPage.Icon = "round_person_white_24dp.png";
                navigationPage.Title = "Profile";

                navigationPage.BarBackgroundColor = Color.FromHex("#e21f4f");
                Children.Add(navigationPage);
            }
            else
            {
                Children.Add(new LogInpage(true));
            }

            var pages = Children.GetEnumerator();
            pages.MoveNext(); // First page
            pages.MoveNext(); // Second page
            CurrentPage = pages.Current;
        }
    }

    
}
