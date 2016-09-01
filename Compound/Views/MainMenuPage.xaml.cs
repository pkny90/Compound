using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Compound
{
	public partial class MainMenuPage : ContentPage
	{
		
		public MainMenuPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			SizeChanged += OnSizeChanged;		
		}

		void OnSizeChanged(object sender, EventArgs e)
		{
			
		}

		public void GoToHighScorePage(object sender, EventArgs e)
		{
			var highscorePage = new HighScorePage();
			Navigation.PushAsync(highscorePage);
		}
		public void GoToAboutPage(object sender, EventArgs e)
		{
			var aboutPage = new AboutPage();
			Navigation.PushAsync(aboutPage);
		}

		async void ChooseDifficulty(object sender, EventArgs e)
		{
			var action = await DisplayActionSheet("Please select a difficulty:", "Cancel", null, "Easy", "Medium", "Hard");
			Debug.WriteLine("Action: " + action);

		}
	}
}

