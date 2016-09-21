using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class GameFinishPage : ContentPage
	{
		private int k;
		bool soundIsPlaying;
		public GameFinishPage(int i,bool IsSoundPlay,int reason)
		{
			InitializeComponent();

			this.BackgroundImage = "backgound1.png";
			k = i;
			soundIsPlaying = IsSoundPlay;
			switch(reason)
			{
				case 1:
				wordRunout.Text = "No more words. The game is Finished!";
					break;
				case 2:
					wordRunout.Text = "Congratulations!";
					break;
				case 3:
					wordRunout.Text = "Sorry, the lives ran out";
					break;
			}
			Score.Text = "Your Score is "+k.ToString();


			ToolbarItem soundToolbar;
			if (soundIsPlaying)
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);

			ToolbarItems.Add(soundToolbar);
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

		public void GotoHighScore(object sender, System.EventArgs e)
		{
			Score score = new Score(playerName.Text, k);
			DataAccessService db = new DataAccessService();
			db.InsertHighScore(score);
			var mainPage = new NavigationPage(new HighScorePage(soundIsPlaying));
			Navigation.PushModalAsync(mainPage);
		}

		public void GoHome(object sender, EventArgs e)
		{
			var mainPage = new NavigationPage(new MainMenuPage(soundIsPlaying));
			Navigation.PushModalAsync(mainPage);
		}
	}
}
