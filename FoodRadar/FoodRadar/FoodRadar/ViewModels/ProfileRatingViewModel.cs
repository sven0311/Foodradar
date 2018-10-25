using FoodRadar.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using static FoodRadar.ProfileRatingsPage;

namespace FoodRadar.ViewModels
{
    public class ProfileRatingViewModel : ViewModelBase
    {
        public static IList<ProfileRatingViewModel> all;

        public void addToString(String s)
        {
            desc += s;
        }

        public String desc { get; set; }
        public Rating rating { get; set; }
        public String restaurantName { get; set; }
        public String mealName { get; set; }
        
        public IList<ProfileRatingViewModel> All
        {
            get
            {
                return buildList();
            }
        }

        public String Desc
        {
            get
            {
                return desc;
            }
            set
            {
                if(desc != value)
                {
                    desc = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<ProfileRatingViewModel> buildList()
        {
            List<ProfileRatingViewModel> l = new List<ProfileRatingViewModel>();
            foreach (Rating r in App.Database.getRatingsforCustomer(LoginViewModel.customer.Id).Result)
            //foreach (Rating r in App.Database.getRatings().Result)
            {
                ProfileRatingViewModel listIt = new ProfileRatingViewModel();
                Meal m = App.Database.getMealById(r.mealId);
                if (m != null)
                {
                    listIt.mealName = m.name;
                    listIt.addToString(m.name + " at ");
                    Restaurant rest = App.Database.getRestaurantById(m.restaurantId);
                    if (rest != null)
                    {
                        listIt.restaurantName = rest.name;
                        listIt.addToString(rest.name + ": ");
                        listIt.addToString(r.rate + " Stars");
                        listIt.rating = r;
                        l.Add(listIt);
                    }
                }
            }
            return l;
        }

    }

}
