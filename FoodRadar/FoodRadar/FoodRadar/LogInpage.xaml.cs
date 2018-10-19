using System;
using App;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodRadar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInpage : ContentPage
	{
		public LogInpage()
		{
			InitializeComponent();
            

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        private async void Button_LogIn(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
        }

    }


}