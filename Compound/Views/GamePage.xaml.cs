using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Compound
{
	public partial class GamePage : ContentPage
	{
		Game game;
		private bool soundIsPlaying = true;

		public GamePage(bool soundIsPlaying)
		{
			this.soundIsPlaying = soundIsPlaying;

			InitializeComponent();
			game = new Game();

			ToolbarItem soundToolbar;
			if (soundIsPlaying)
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);
			ToolbarItems.Add(soundToolbar);


			// Initalise images
			firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
			secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));
		}

		public GamePage(bool soundIsPlaying, Game game)
		{
			this.game = game;
			this.soundIsPlaying = soundIsPlaying;

			InitializeComponent();

			ToolbarItem soundToolbar;
			if (soundIsPlaying)
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);
			ToolbarItems.Add(soundToolbar);


			scoreLabel.Text = "Score: " + game.Score;

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

			string answerWord = game.currentWord.word;
			string answerImage = game.currentWord.answer_image;

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
				
			}

			var answerPage = new GameAnswerPage(game, answerImage, answerWord);
			Navigation.PushModalAsync(answerPage);
		}

		private void ExitGame()
		{
			Score score = new Score("Zoey", game.Score);
			DataAccessService db = new DataAccessService();
			db.InsertHighScore(score);

			var mainPage = new MainMenuPage(soundIsPlaying);
			Navigation.PushAsync(mainPage);
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
	}
}
