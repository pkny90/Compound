using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Compound
{
	public partial class HighScorePage : ContentPage
	{
		bool soundIsPlaying;
		public HighScorePage(bool soundIsPlaying)
		{
			InitializeComponent();

			this.BackgroundImage = "backgound1.png";
			this.soundIsPlaying = soundIsPlaying;
			ToolbarItem Gohome;
 			Gohome = new ToolbarItem("Home", "ic_home_2x.png", gohome);
 			ToolbarItems.Add(Gohome);
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

		void gohome()
 		{
 			var mainPage = new NavigationPage(new MainMenuPage(soundIsPlaying));
 			Navigation.PushModalAsync(mainPage);
 		}
	}
}

