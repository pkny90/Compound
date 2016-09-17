using System;
using SQLite;
namespace Compound
{
	public interface IDBConnection
	{
		SQLiteAsyncConnection GetSQLiteAsyncConnection();
	}
}

