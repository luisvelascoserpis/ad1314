using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
		
		private static IEnumerable<string> getColumnNames(MySqlDataReader mySqlDataReader) {
			int fieldCount = mySqlDataReader.FieldCount;
			string[] columnNames = new string[ fieldCount ];
			for (int index = 0; index < fieldCount; index++)
				columnNames[index] = mySqlDataReader.GetName (index);
			return columnNames;
		}

		private static IEnumerable<string> getColumnNames2(MySqlDataReader mySqlDataReader) {
			int fieldCount = mySqlDataReader.FieldCount;
			List<string> columnNames = new List<string>();
			for (int index = 0; index < fieldCount; index++)
				columnNames.Add ( mySqlDataReader.GetName(index) );
			return columnNames;
		}
	}
}
