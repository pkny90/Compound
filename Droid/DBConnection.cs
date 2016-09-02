using System;
using System.IO;
using Compound;
using Compound.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DBConnection))]
namespace Compound.iOS
{
	public class DBConnection : IDBConnection
	{
		SQLiteAsyncConnection IDBConnection.GetSQLiteAsyncConnection()
		{
			var personalFolder =
				Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryFolder = Path.Combine(personalFolder, "..", "files");
			var dbPath = Path.Combine(libraryFolder, CONSTANTS.DATABASEPATH);
			var connection = new SQLiteAsyncConnection(dbPath);
			return connection;
		}
	}
}

