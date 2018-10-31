using System;
using App;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodRadar.Database.DatabaseModels;
using FoodRadar.ViewModels;
using PageNavSingleton;

namespace FoodRadar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogInpage : ContentPage
	{

        public LogInpage(bool later)
		{
			InitializeComponent();

            if (later)
            {
                skip.IsVisible = false;
            }
            if (App.LoginStatus == 0 || App.LoginStatus == 1)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            if (App.LoginStatus == 2)
                NavigationPage.SetHasNavigationBar(this, true);
        }
    }

}