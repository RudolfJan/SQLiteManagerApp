using System.Data;
using System.Data.SQLite;

using Dapper;

namespace SQLiteManager.Library
{
	public class DataAccess
	{
		public static IEnumerable<T>? LoadData<T, U>(string sqlStatement, U parameters, string conntectionString)
		{
			using ( IDbConnection connection = new SQLiteConnection(conntectionString) )
			{
				IEnumerable<T>? rows = connection.Query<T>(sqlStatement, parameters);
				return rows;
			}
		}

		public static Task<IEnumerable<T>>? LoadDataAsync<T, U>(string sqlStatement, U parameters, string conntectionString)
		{
			using ( IDbConnection connection = new SQLiteConnection(conntectionString) )
			{
				Task<IEnumerable<T>>? rows = connection.QueryAsync<T>(sqlStatement, parameters);
				return rows;
			}
		}

		public static void SaveData<T>(string sqlStatement, T parameters, string connectionString)
		{
			using ( IDbConnection connection = new SQLiteConnection(connectionString) )
			{
				_ = connection.Execute(sqlStatement, parameters);
			}
		}

		public static Task SaveDataAsync<T>(string sqlStatement, T parameters, string connectionString)
		{
			using ( IDbConnection connection = new SQLiteConnection(connectionString) )
			{
				return connection.ExecuteAsync(sqlStatement, parameters);
			}
		}
	}
}
