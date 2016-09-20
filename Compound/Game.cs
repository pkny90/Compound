using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Compound
{
    public class Game
    {
		public Word currentWord { get; private set; }
        public int Score { get; private set; }
        public int RemainingLives { get; private set; }

		public List<Word> remainingGameWords;
        public Game()
        {
		    this.Score = 0;
            this.RemainingLives = 3;

			this.remainingGameWords = GetWordsFromJsonFile("Compound.Data.wordlist.json");
			StartNewRound();

			System.Diagnostics.Debug.WriteLine(currentWord.word);
        }

		private List<Word> GetWordsFromJsonFile(string fileName) 
		{
			FileReader fileReader = new FileReader(fileName);
			string jsonText = fileReader.JsonText;

			return JsonConvert.DeserializeObject<List<Word>>(jsonText);

		}

        public void StartNewRound()
        {
			// Pick a random word and remove it from the list
			Random random = new Random();
			var i = random.Next(remainingGameWords.Count);

			if (i >= remainingGameWords.Count)
			{
				currentWord = null;
			}
			else 
			{
				currentWord = remainingGameWords[i];
				remainingGameWords.RemoveAt(i);

			}
        }

		public String MakeGuess(string Guess)
		{
			string res;
			if (Guess == currentWord.word)
            {
				StartNewRound();

				this.Score += 1000;
				res = "Nice job!";
                return res;
            }
            else
            {
				StartNewRound();

				this.RemainingLives--;
				res = "Nice try! Better luck next time.";
                return res;
            }
        }

        public string GetHint()
        {
            Score -= 500;
            var randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(1, 2);

            if (randomNumber == 1)
            {
				
				return "The first half of the word is: " + this.currentWord.first_word;
            }
            else
            {
				return "The second half of the word is: " + this.currentWord.second_word;
            }
        }
    }
}
