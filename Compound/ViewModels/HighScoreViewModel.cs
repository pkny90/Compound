using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace Compound
{
	public class HighScoreViewModel
	{
		public ObservableCollection<Score> HighScoresList { get; set; }

		public HighScoreViewModel()
		{
			// TODO: Replace hardcoded scores with querying a database and getting them
			this.HighScoresList = new ObservableCollection<Score>(
				new Score[] {
				new Score("Zoey", 100),
				new Score("Amy", 95)
			});
		}
	}
}

