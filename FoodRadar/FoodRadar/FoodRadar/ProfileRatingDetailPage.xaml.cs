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
    public partial class ProfileRatingDetailPage : ContentPage
    {

        public ProfileRatingDetailPage(ListIt listIt)
        {
            InitializeComponent();
            buildPage(listIt);
        }

        private async void Button_Back(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Profile();
            await Navigation.PopModalAsync();
        }

        private void buildPage(ListIt listIt)
        {
            var restaurant = new Label
            {
                Text = "Restaurant: " + listIt.restaurantName,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var meal = new Label
            {
                Text = "Meal: " + listIt.mealName,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var rate = new Label
            {
                Text = "Rating: " + listIt.rating.rate,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var desc = new Label
            {
                Text = "Description: " + listIt.rating.desc,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var delete = new Button()
            {
                Text = "Delete Rating",

            };
            delete.Clicked += async (sender, args) =>
            {
                await App.Database.DeleteRatingAsync(listIt.rating);
                await Navigation.PopModalAsync();
            };
            
            var firstStack = new StackLayout()
            {
                Children = { restaurant, meal, rate, desc, delete },
            };

            Content = firstStack;

        }
    }
}