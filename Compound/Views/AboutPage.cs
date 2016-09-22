using System;

using Xamarin.Forms;

namespace Compound
{
	public class AboutPage : ContentPage
	{
		bool soundIsPlaying;

		public AboutPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}


	}
}


