using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodRadar.ViewModels
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddReviewViewModel : ContentPage
	{
		public AddReviewViewModel ()
		{
			InitializeComponent ();
		}
	}
}