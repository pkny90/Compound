using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compound
{
    class Game
    {
        public string Word { get; private set; }
        public string FirstHalfWord { get; private set; }
        public string SecondHalfWord { get; private set; }

        public int Score { get; private set; }
        public int RemainingLives { get; private set; }

        public Game()
        {
		    this.Score = 0;
            this.RemainingLives = 3;

            StartNewRound();
        }

        public void StartNewRound()
        {
			JsonReader reader = new JsonReader("Compound.Data.wordlist.json");
			string jsonText = reader.JsonText;
			System.Diagnostics.Debug.WriteLine(jsonText);
        }

        public bool MakeGuess(string Guess)
        {
            if (Guess == Word)
            {
                this.Score += 1000;
                return true;
            }
            else
            {
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
                return this.FirstHalfWord;
            }
            else
            {
                return this.SecondHalfWord;
            }
        }
    }
}
