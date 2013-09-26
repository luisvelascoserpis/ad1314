using System;
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionString = 
				"Server=localhost;" +
				"Database=dbprueba;" +
				"User Id=root;" +
				"Password=sistemas"; 
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			
			mySqlConnection.Open ();
			
			//select * from categoria
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
			mySqlCommand.CommandText = "select * from articulo";
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
			
//			int fieldCount = mySqlDataReader.FieldCount;
//			for (int index = 0; index < fieldCount; index++)
//				Console.Write ( mySqlDataReader.GetName( index ) + "  " ) ;
//			
//			Console.WriteLine ();
			
			Console.WriteLine( string.Join("  ", getColumnNames(mySqlDataReader)) );
			
			mySqlDataReader.Close();
			mySqlConnection.Close ();
			Console.WriteLine ("Ok"); 
		}
		
		private static string[] getColumnNames(MySqlDataReader mySqlDataReader) {
			//string[] columnNames = new string[ mySqlDataReader.FieldCount ];
			return new string[]{};
		}
	}
}
