using System;
using Xamarin.Forms;

namespace Compound
{
	public partial class MainMenuPage : ContentPage
	{
		public MainMenuPage()
		{
			InitializeComponent();
		}

		public void GoToHighScorePage(object sender, EventArgs e) 
		{
			var highscorePage = new HighScorePage();
			Navigation.PushAsync(highscorePage);
		}
	}
}

