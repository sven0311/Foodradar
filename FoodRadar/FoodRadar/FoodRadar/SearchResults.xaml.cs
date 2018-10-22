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
    public partial class SearchResults : ContentPage
    {
        public List<Restaurant> restaurants;

        public SearchResults()
        {
            InitializeComponent();
            CreateTable();

        }


        public void CreateTable()
        {
            var table = new TableView();
            table.Intent = TableIntent.Settings;
            var layout = new StackLayout() { Orientation = StackOrientation.Horizontal };
            layout.Children.Add(new Image() { Source = "bulb.png" });
            layout.Children.Add(new Label()
            {
                Text = "left",
                TextColor = Color.FromHex("#f35e20"),
                VerticalOptions = LayoutOptions.Center
            });
            layout.Children.Add(new Label()
            {
                Text = "right",
                TextColor = Color.FromHex("#503026"),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.EndAndExpand
            });
            table.Root = new TableRoot() {
                new TableSection("Getting Started") {
                    new ViewCell() {View = layout}
                }
            };

            Content = table;
        }
        

        public SearchResults(List<Restaurant> rst)
        {
            restaurants = rst;
            InitializeComponent();
        }

        public List<Restaurant> getRestaurants
        {
            get
            {
                return restaurants;
            }
        }

	}
}