using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Compound
{
    class Game
    {
		public Word currentWord { get; private set; }
        public int Score { get; private set; }
        public int RemainingLives { get; private set; }

		private List<Word> remainingGameWords;
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

			currentWord = remainingGameWords[i];
			remainingGameWords.RemoveAt(i);
        }

        public bool MakeGuess(string Guess)
        {
			if (Guess == currentWord.word)
            {
				StartNewRound();

				this.Score += 1000;
                return true;
            }
            else
            {
				StartNewRound();

				this.RemainingLives--;
                return false;
            }
        }

        public string GetHint(string Hint)
        {
            Score -= 500;
            var randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(1, 2);

            if (randomNumber == 1)
            {
				return this.currentWord.first_word;
            }
            else
            {
				return this.currentWord.second_word;
            }
        }
    }
}
