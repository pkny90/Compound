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

			firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
			secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));
		}

		void Submit_Answer_Clicked(object sender, System.EventArgs e)
		{
			string guess = guessText.Text;
			game.MakeGuess(guess.ToLower());

			guessText.Text = "";
			scoreLabel.Text = game.Score.ToString();
			 
			firstImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.first_image));
			secondImage.Source = ImageSource.FromResource(string.Format("Compound.Images.{0}", game.currentWord.second_image));
		}
	}
}

