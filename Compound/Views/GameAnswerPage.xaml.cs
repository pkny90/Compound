using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class GameAnswerPage : ContentPage
	{
		private Game game;
		private double width;
		private double height;
		private bool soundIsPlaying;

		public GameAnswerPage(bool soundIsPlaying, Game game, string previousWordImage, string previousWord,string a)
		{
			InitializeComponent();
			this.game = game;
			this.soundIsPlaying = soundIsPlaying;
			this.BackgroundImage = "backgound1.png";

			NavigationPage.SetHasBackButton(this, false);

			ToolbarItem soundToolbar;

			if (soundIsPlaying)
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);

			ToolbarItems.Add(soundToolbar);

			answerImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", previousWordImage));
			answerWord.Text =previousWord;

			userFeedback.Text = ""+game.Score;
			rightOrWrong.Text = a;
		}

		void NextWordClicked(object sender, System.EventArgs e)
		{
			var gamePage = new GamePage(soundIsPlaying, game);
			Navigation.PushAsync(gamePage);
		}

		void ExitGameClicked(object sender, System.EventArgs e)
		{
			var mainPage = new NavigationPage(new GameFinishPage(game.Score,soundIsPlaying,2));
			Navigation.PushModalAsync(mainPage);
		}

		private void SwapSoundIcon()
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
				newSoundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);

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
					answerlayout.Orientation = StackOrientation.Horizontal;
				}
				else {
					answerlayout.Orientation = StackOrientation.Vertical;
				}
			}
		}
	}
}

