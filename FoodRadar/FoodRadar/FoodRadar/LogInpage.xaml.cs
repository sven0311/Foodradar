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

            MessagingCenter.Subscribe<LoginViewModel>(this, "blank", (sender) => {
                // do something whenever the "Hi" message is sent
            });
        }
    }

}