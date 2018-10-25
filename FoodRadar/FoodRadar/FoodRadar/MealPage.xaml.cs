using FoodRadar.Database.DatabaseModels;
using FoodRadar.Views;
using PageNavSingleton;
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

        public Command Restaurant_clicked { protected set; get; }
        private PageNavigationManager navManager = PageNavigationManager.Instance;
        MealListView meal;
		public MealPage (MealListView meal)
		{
			InitializeComponent ();
            this.meal = meal;
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#e21f4f");

            Restaurant_clicked = new Command(() =>
            {
                //navManager.popModalAsync();
                navManager.showRestaurantPage(new RestaurantListView(App.Database.GetRestaurantById(meal.restaurantId)));
                
            });

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

            var Restaurant_button = new Button()
            {
                BindingContext = "SearchViewModel",
                Command = Restaurant_clicked,

            };




           

            var parentStack = new StackLayout()
            {
                Children = { firstStack, Restaurant_button }
            };

            Padding = new Thickness(0, 20, 0, 0);
            Content = parentStack;
        }

	}
}