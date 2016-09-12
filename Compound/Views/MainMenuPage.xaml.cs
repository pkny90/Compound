using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Compound
{
	public partial class MainMenuPage : ContentPage
	{
		private bool soundIsPlaying = true;

		public MainMenuPage()
		{
			InitializeComponent();
			var soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);

			ToolbarItems.Add(soundToolbar);
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

		}

		public void SwapSoundIcon()
		{
			ToolbarItems.Clear();
			ToolbarItem newSoundToolbar;

			if (soundIsPlaying)
			{
				soundIsPlaying = false;
				newSoundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);
				DependencyService.Get<IAudio>().Stop();
			}
			else
			{
				soundIsPlaying = true;
				newSoundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);;
				DependencyService.Get<IAudio>().PlayAudioFile("yayayaya.mp3");
			}
			ToolbarItems.Add(newSoundToolbar);
		}
	}
}

