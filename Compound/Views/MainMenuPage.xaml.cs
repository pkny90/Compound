using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Compound
{
	public partial class MainMenuPage : ContentPage
	{
		private bool soundIsPlaying;

		public MainMenuPage(bool soundIsPlaying)
		{
			this.soundIsPlaying = soundIsPlaying;

			InitializeComponent();

			ToolbarItem soundToolbar;
			if (soundIsPlaying) 
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);

			ToolbarItems.Add(soundToolbar);
			// DependencyService.Get<IAudio>().PlayAudioFile("yayayaya.mp3");
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
			await DisplayActionSheet("Please select a difficulty:", "Cancel", null, "Easy", "Medium", "Hard");
			var gamePage = new GamePage(soundIsPlaying);
			Navigation.PushAsync(gamePage);
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

