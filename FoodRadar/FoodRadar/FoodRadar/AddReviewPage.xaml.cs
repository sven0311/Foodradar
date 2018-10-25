using FoodRadar.Database.DatabaseModels;
using FoodRadar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodRadar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReviewPage : ContentPage
    {
        public Meal meal { get; set; }
        public AddReviewPage(Meal meal)
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#e21f4f");
            this.meal = meal;
            AddReviewViewModel rm = new AddReviewViewModel(meal);
            BindingContext = rm;

        }


    }
}