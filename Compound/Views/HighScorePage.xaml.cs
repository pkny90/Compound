using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class HighScorePage : ContentPage
	{
		private bool soundIsPlaying = true;
		public HighScorePage()
		{
			InitializeComponent();
			var soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", async () => {
				SwapSoundIcon();	
			});

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
			}
			else 
			{
				soundIsPlaying = true;
				newSoundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			}
			ToolbarItems.Add(newSoundToolbar);
		}
	}
}

