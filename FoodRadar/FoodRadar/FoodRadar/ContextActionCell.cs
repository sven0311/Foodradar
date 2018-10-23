using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace WorkingWithListview
{
    /// <summary>
    /// For custom renderer on Android (only)
    /// </summary>
    public class ListButton : Button { }


    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var restaurantName = new Label
            {
                Text = "Label 1",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            };
            restaurantName.SetBinding(Label.TextProperty, new Binding("."));

            var stars = new Label
            {
                Text = "Label 2",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };
            stars.SetBinding(Label.TextProperty, new Binding("."));
            var price = new Label
            {
                Text = "Label 2",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };
            price.SetBinding(Label.TextProperty, new Binding("."));



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