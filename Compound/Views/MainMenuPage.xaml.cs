using System;
using Xamarin.Forms;

namespace Compound
{
	public partial class MainMenuPage : ContentPage
	{
		public MainMenuPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		public void GoToHighScorePage(object sender, EventArgs e) 
		{
			var highscorePage = new HighScorePage();
			Navigation.PushAsync(highscorePage);
		}
	}
}

