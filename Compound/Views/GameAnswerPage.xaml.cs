using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class GameAnswerPage : ContentPage
	{
		private Game game;

		public GameAnswerPage(Game game, string previousWordImage, string previousWord)
		{
			this.game = game;

			InitializeComponent();

			answerImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", previousWordImage));
			answerWord.Text = "The word was " + previousWord;

			userFeedback.Text = "Nice job!\nCurrent Score: " + game.Score;
		}

		void NextWordClicked(object sender, System.EventArgs e)
		{
			var gamePage = new GamePage(false, game);
			Navigation.PushModalAsync(gamePage);
		}

		void ExitGameClicked(object sender, System.EventArgs e)
		{
			var mainPage = new NavigationPage(new MainMenuPage(false));

			Navigation.PushModalAsync(mainPage);
		}
	}
}

