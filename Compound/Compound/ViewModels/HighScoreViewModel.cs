using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Compound
{
	public class HighScoreViewModel :INotifyPropertyChanged
	{
		ObservableCollection<Score> _HighScoresList;

		public event PropertyChangedEventHandler PropertyChanged;
		bool _dataLoaded;
		public bool DataLoaded
		{
			get { return _dataLoaded;}
			set
			{
				_dataLoaded = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("DataLoaded"));
				}
			}
		}

		public ObservableCollection<Score> HighScoresList
		{
			get { return _HighScoresList;}
			set { 
				_HighScoresList = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("HighScoresList"));
					DataLoaded = false;
				}
				}
		}

		public HighScoreViewModel()
		{
			DataLoaded = true;
			FetchScoreDataAsync();
			/*_HighScoresList = new ObservableCollection<Score>();
			// TODO: Replace hardcoded scores with querying a database and getting them
			_HighScoresList.Add(
				new Score { PlayerName = "Zoey", PlayerScore = 100 }); 
			_HighScoresList.Add(
	   			new Score { PlayerName = "Amy", PlayerScore = 94 });*/
		}

		public async Task FetchScoreDataAsync()
		{
			DataAccessService service = new DataAccessService();
			var list = await service.GetAllScoresAsync();
			HighScoresList = new ObservableCollection<Score>(list);
		}
	}
}

