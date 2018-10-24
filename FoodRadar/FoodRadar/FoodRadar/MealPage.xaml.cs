using FoodRadar.Database.DatabaseModels;
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
	public partial class MealPage : ContentPage
	{
        Meal meal;
		public MealPage (Meal meal)
		{
			InitializeComponent ();
            this.meal = meal;
            constructPage();
		}

        public void constructPage()
        {


            var mealName = new Label
            {
                Text = meal.name,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var mealPrice = new Label
            {
                Text = meal.price.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };

            var mealRating = new Label
            {
                Text = meal.rating.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };


            var firstStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Children = { mealName, mealPrice, mealRating },
            };




           

            var parentStack = new StackLayout()
            {
                Children = { firstStack }
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = parentStack;
        }

	}
}