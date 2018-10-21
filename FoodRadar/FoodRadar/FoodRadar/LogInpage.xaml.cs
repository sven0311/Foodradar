using System;
using App;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodRadar.Database.DatabaseModels;

namespace FoodRadar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInpage : ContentPage
	{
        
        public bool loggedIn = false;
        public Customer customer = null;

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
            //await Navigation.PushAsync(new Profile());
            //Customer cust = App.Database.getPassword(email);
            //if (cust == null)
            //{
            //    //pop up message (email not found)
            //}
            //if (cust.password == password)
            //{
            //    loggedIn = true;
            //    customer = cust;
            //}
        }

        private String email;
        private String Email
        {
            get
            {
                return email;
            }
        }

        private String password;
        private String Password
        {
            get
            {
                return password;
            }
        }

    }


}