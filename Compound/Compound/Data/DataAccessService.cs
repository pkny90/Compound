using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
			myConnection.InsertAsync(new Score { PlayerName = "Aya", PlayerScore = 99 });
		}
		public async Task<List<Score>> GetAllScoresAsync()
		{
			var list = await myConnection.Table<Score>().ToListAsync();
			return list;
		}
		public async Task InsertSessionAsync(Score score)
		{
			await myConnection.InsertAsync(score);
		}
	}
}

