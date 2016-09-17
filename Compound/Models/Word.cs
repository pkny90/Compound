using System;

namespace Compound
{
	public class Word
	{
		public string word { get; set; }
		public string first_image { get; set; }
		public string second_image { get; set; }
		public string answer_image { get; set; }
		public string first_word { get; set; }
		public string second_word { get; set; }

		public Word(string word, string firstImage, string secondImage,
		           string answerImage, string firstWord, string secondWord)
		{
			this.word = word;
			this.first_image = firstImage;
			this.second_image = secondImage;
			this.answer_image = answerImage;
			this.first_word = firstWord;
			this.second_word = secondWord;
		}
	}
}

