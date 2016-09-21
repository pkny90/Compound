using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Compound
{
	public partial class MainMenuPage : ContentPage
	{
		private bool soundIsPlaying;
		private double width;
		private double height;

		public MainMenuPage(bool soundIsPlaying)
		{
			this.soundIsPlaying = soundIsPlaying;

			InitializeComponent();
			this.BackgroundImage = "backgound1.png";

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
			var highscorePage = new HighScorePage(soundIsPlaying);
			Navigation.PushAsync(highscorePage);
		}

		public void GoToAboutPage(object sender, EventArgs e)
		{
			//var aboutPage = new AboutPage();
			//Navigation.PushAsync(aboutPage);
		}

		async void ChooseDifficulty(object sender, EventArgs e)
		{
			var action = await DisplayActionSheet("Please select a difficulty:", "Cancel", null, "Easy", "Medium", "Hard");
			if (action == "Easy")
			{
<<<<<<< HEAD
				var gamePage = new GamePage(soundIsPlaying,3);
=======
				var gamePage = new GamePage(soundIsPlaying,1);
>>>>>>> feature/add-difficulties-and-end-game-page
				await Navigation.PushAsync(gamePage);
			}
			if (action == "Medium")
			{
				var gamePage = new GamePage(soundIsPlaying,2);
				await Navigation.PushAsync(gamePage);
			}
			if (action == "Hard")
			{
<<<<<<< HEAD
				var gamePage = new GamePage(soundIsPlaying,1);
=======
				var gamePage = new GamePage(soundIsPlaying,3);
>>>>>>> feature/add-difficulties-and-end-game-page
				await Navigation.PushAsync(gamePage);
			}
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

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			if (width != this.width || height != this.height)
			{
				this.width = width;
				this.height = height;
				if (width > height)
				{
					outerStack.Orientation = StackOrientation.Horizontal;
				}
				else {
					outerStack.Orientation = StackOrientation.Vertical;
				}
			}
			
		}
	}
}

