using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class GamePage : ContentPage
	{
		Game game;

		public GamePage()
		{
			InitializeComponent();
			game = new Game();

			// Initalise images
			firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
			secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));
		}

		void Submit_Answer_Clicked(object sender, System.EventArgs e)
		{
			string guess = guessText.Text;
			if (guess == null)
			{
				guess = "this is the wrong answer.";
			}
			game.MakeGuess(guess.ToLower());

			guessText.Text = "";
			scoreLabel.Text = game.Score.ToString();
			 
			// End the game if their are no words left as an exception will be thrown
			try
			{
				firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
				secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));
			}
			catch (NullReferenceException) 
			{
				ExitGame();
			}

		}

		private void ExitGame() 
		{
			Score score = new Score("Zoey", game.Score);
			DataAccessService db = new DataAccessService();
			db.InsertHighScore(score);

			var mainPage = new MainMenuPage();
			Navigation.PushAsync(mainPage);
		}
	}
}

