using System;
namespace Compound
{
	public class Score
	{
		public string PlayerName 
		{ 	get; 
			set; 
		}
		int _PlayerScore;
		public int PlayerScore 
		{ 
			get { return _PlayerScore;} 
			set { _PlayerScore = value; }
		}

		public Score()
		{
			PlayerName = "default";
			PlayerScore = 60;
		}

		public void InsertScore(String name, int score)
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

