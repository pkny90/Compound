using System;
namespace Compound
{
	public class Score
	{
		public string PlayerName { get; private set; }
		public int PlayerScore { get; private set; }

		public Score(string name, int score)
		{
			this.PlayerName = name;
			this.PlayerScore = score;
		}

		public override string ToString()
		{
			return string.Format("{0}\t{1}", PlayerName, PlayerScore);
		}
	}
}

