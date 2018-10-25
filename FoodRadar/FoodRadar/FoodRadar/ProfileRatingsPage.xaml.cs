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
	public partial class ProfileRatingsPage : ContentPage
	{
		public ProfileRatingsPage ()
		{
			InitializeComponent();
            //var l = App.Database.getRatings().Result;

            listView.ItemsSource = buildList();
            listView.ItemTapped += async (sender, e) => {

                await Navigation.PushModalAsync(new ProfileRatingDetailPage((ListIt)e.Item));
            };
        }

        private List<ListIt> buildList()
        {
            List<ListIt> l = new List<ListIt>();
            foreach (Rating r in App.Database.getRatingsforCustomer(LoginViewModel.customer.Id).Result)
            //foreach (Rating r in App.Database.getRatings().Result)
            {
                ListIt listIt = new ListIt();
                Meal m = App.Database.getMealById(r.mealId);
                if (m != null)
                {
                    listIt.mealName = m.name;
                    listIt.addToString(m.name + " at ");
                    Restaurant rest = App.Database.getRestaurantById(m.restaurantId);
                    if (rest != null)
                    {
                        listIt.restaurantName= rest.name;
                        listIt.addToString(rest.name + ": ");
                        listIt.addToString(r.rate + " Stars");
                        listIt.rating = r;
                        l.Add(listIt);
                    }
                }
            }
            return l;
        }

        private async void Button_Back(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Profile();
            await Navigation.PopModalAsync();
        }
    }

    public class ListIt
    {
        public String desc { get; set; }
        public Rating rating { get; set; }
        public String restaurantName { get; set; }
        public String mealName { get; set; }

        public void addToString(String s)
        {
            desc += s;
        }
    }
}