using FoodRadar.Database.DatabaseModels;
using FoodRadar.DB;
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
	public partial class SignUpPage: ContentPage
	{
		public SignUpPage()
		{
            InitializeComponent();
        }

        private async void Button_ok(object sender, EventArgs e)
        {
            var fn = FirstName.Text;
            var ln = LastName.Text;
            var em = Email.Text;
            var pw = Password.Text;
            var cpw = ConfirmPassword.Text;

            Customer x = await App.Database.CheckEmail(em);

            if (x != null)
            {
                await DisplayAlert("Email already signed up", "Please try another email", "Try again");
            }
            else if (cpw != pw)
            {
                await DisplayAlert("Password Confirmation Fail", "", "Try again");
            }
            else
            {
                //create new costumer
                x = new Customer
                {
                    lastName = ln,
                    firstName = fn,
                    password = pw,
                    email = em
                };

                App.Database.SaveItemAsync(x);

                await DisplayAlert("Sign up complete!", "", "Go Browse");

                Application.Current.MainPage = new MainPage();

            }
        }

    }
}