using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace Compound
{
	public class DataAccessService
	{
		SQLiteAsyncConnection myConnection = null;
		public DataAccessService()
		{
			myConnection = DependencyService.Get<IDBConnection>().GetSQLiteAsyncConnection();
			myConnection.CreateTableAsync<Score>();
		}
		public async Task<List<Score>> GetAllScoresAsync()
		{
			// Ensure the high score page displays by highest score
			var list = await myConnection.Table<Score>().ToListAsync();
			list = list.OrderBy(s => s.PlayerScore)
			           .Reverse()
			           .ToList();
			
			return list;
		}
		public async Task InsertSessionAsync(Score score)
		{
			await myConnection.InsertAsync(score);
		}

		public void InsertHighScore(Score score)
		{
			myConnection.InsertAsync(score);
		}
	}
}

