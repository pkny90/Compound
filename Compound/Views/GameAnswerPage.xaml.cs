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

		public GameAnswerPage(Game game, string previousWordImage, string previousWord,string a)
		{
			this.game = game;

			InitializeComponent();

			answerImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", previousWordImage));
			answerWord.Text =previousWord;

			userFeedback.Text = ""+game.Score;
			rightOrWrong.Text = a;
		}

		void NextWordClicked(object sender, System.EventArgs e)
		{
			var gamePage = new GamePage(false, game);
			Navigation.PushAsync(gamePage);
		}

		void ExitGameClicked(object sender, System.EventArgs e)
		{

			Score score = new Score("Zoey", game.Score);
			DataAccessService db = new DataAccessService();
			db.InsertHighScore(score);
			var mainPage = new NavigationPage(new MainMenuPage(false));
			Navigation.PushAsync(mainPage);
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

