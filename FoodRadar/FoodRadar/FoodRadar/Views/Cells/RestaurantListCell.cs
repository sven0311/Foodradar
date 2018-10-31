using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Foodradar.Views.Cells
{
    /// <summary>
    /// For custom renderer on Android (only)
    /// </summary>


    public class RestaurantListCell : ViewCell
    {
        public RestaurantListCell()
        {
            var restaurantName = new Label
            {
                Text = "Label 1",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            restaurantName.SetBinding(Label.TextProperty, new Binding("name"));

            var stars = new Label
            {
                Text = "Label 2",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };
            stars.SetBinding(Label.TextProperty, new Binding("rating"));
            var price = new Label
            {
                Text = "Label 2",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };
            price.SetBinding(Label.TextProperty, new Binding("price"));



            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(15, 5, 5, 15),
                Children = {
                    new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                        Children = { restaurantName, stars, price }
                    }
                }
            };
        }
    }
}