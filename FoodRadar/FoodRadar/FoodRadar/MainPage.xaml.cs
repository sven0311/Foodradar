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
            var pages = Children.GetEnumerator();
            pages.MoveNext(); // First page
            pages.MoveNext(); // Second page
            CurrentPage = pages.Current;
            if (LoginViewModel.loggedIn)
            {
                Children.Add(new Profile());
            } else
            {
                Children.Add(new LogInpage());
            }
        }

       
    }

    
}
