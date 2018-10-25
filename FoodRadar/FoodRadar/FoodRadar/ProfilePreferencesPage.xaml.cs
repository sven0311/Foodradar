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
	public partial class ProfilePreferencesPage : ContentPage
	{
		public ProfilePreferencesPage ()
		{

			InitializeComponent ();
            BindingContext = new ViewModels.ProfilePrefViewModel();
		}

        private async void Button_Back(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Profile();
            await Navigation.PopModalAsync();
        }
    }
}