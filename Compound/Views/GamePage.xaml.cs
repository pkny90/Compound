using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Compound
{
	public partial class GamePage : ContentPage
	{
		Game game;
		private bool soundIsPlaying = true;
		private double width;
		private double height;

		public GamePage(bool soundIsPlaying,int i)
		{
			this.BackgroundImage = "backgound1.png";
			this.soundIsPlaying = soundIsPlaying;

			InitializeComponent();
			game = new Game(SetDifficulty(i));

			ToolbarItem soundToolbar;
			ToolbarItem hints;

			hints = new ToolbarItem("Hints", "ic_lightbulb", UseHints);
			if (soundIsPlaying)
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);
			
			ToolbarItems.Add(soundToolbar);
			ToolbarItems.Add(hints);


			livesLabel.Text = game.RemainingLives.ToString();

			// Initalise images
			firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
			secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));


		}

		public GamePage(bool soundIsPlaying, Game game)
		{

			InitializeComponent();

			this.BackgroundImage = "backgound1.png";
			this.game = game;
			this.soundIsPlaying = soundIsPlaying;

			NavigationPage.SetHasBackButton(this, false);

			ToolbarItem soundToolbar;
			if (soundIsPlaying)
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);
			ToolbarItems.Add(soundToolbar);
			ToolbarItem hints;
			hints = new ToolbarItem("Hints", "ic_lightbulb", UseHints);
			ToolbarItems.Add(hints);

			scoreLabel.Text = game.Score.ToString();
			livesLabel.Text = game.RemainingLives.ToString();

			// Initalise images - will throw exception if no words are left and end the game
			try 
			{
				firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
				secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));
			}
			catch (NullReferenceException)
			{
				WordsRunOut();
			}

			if (game.RemainingLives == 0)
			{
				LivesRunOut();
			}

		}

		async void Submit_Answer_Clicked(object sender, System.EventArgs e)
		{

			string guess = guessText.Text;
			if (guess == null)
			{
				guess = "this is the wrong answer.";
			}

			string answerWord = game.currentWord.word;
			string answerImage = game.currentWord.answer_image;
			String a=game.MakeGuess(guess.ToLower());

			guessText.Text = "";
			scoreLabel.Text = game.Score.ToString();
			livesLabel.Text = game.RemainingLives.ToString();

			// End the game if their are no words left as an exception will be thrown
			try
			{
				firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
				secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));
			}
			catch (NullReferenceException)
			{

			}

			var answerPage = new GameAnswerPage(soundIsPlaying, game, answerImage, answerWord,a);;
			await Navigation.PushAsync(answerPage);
		}

		private void WordsRunOut()
		{
			var mainPage = new NavigationPage(new GameFinishPage(game.Score, soundIsPlaying, 1));
			Navigation.PushModalAsync(mainPage);
		}

		private void LivesRunOut()
		{
			var mainPage = new NavigationPage(new GameFinishPage(game.Score, soundIsPlaying, 3));
			Navigation.PushModalAsync(mainPage);
		}

		private void SwapSoundIcon()
		{
			ToolbarItems.Clear();
			ToolbarItem newSoundToolbar;
			ToolbarItem hints;
			hints = new ToolbarItem("Hints", "ic_lightbulb", UseHints);


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
			ToolbarItems.Add(hints);
		}

		private void UseHints()
		{
			DisplayAlert("Hint", game.GetHint(), "OK");

			// Remove the hint button so no further hints can be used
			ToolbarItems.Clear();
			ToolbarItem soundToolbar;

			if (soundIsPlaying)
				soundToolbar = new ToolbarItem("Sound", "sound-icon-on.png", SwapSoundIcon);
			else
				soundToolbar = new ToolbarItem("Sound", "sound-icon-off.png", SwapSoundIcon);

			ToolbarItems.Add(soundToolbar);

			scoreLabel.Text = game.Score.ToString();
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
					imageStacklayout.Orientation = StackOrientation.Horizontal;
				}
				else {
					imageStacklayout.Orientation = StackOrientation.Vertical;
				}
			}
		}

		private int SetDifficulty(int i)
		{
			int difficulty = i;
			switch (i)
			{
				case 1:
					difficulty = 4;
					break;
				case 2:
					difficulty = 3;
					break;
				case 3:
					difficulty = 2;
					break;
			}
			return difficulty;
		}
	}
}
