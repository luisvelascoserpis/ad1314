using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private MySqlConnection mySqlConnection;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		mySqlConnection = new MySqlConnection("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
		mySqlConnection.Open ();
		
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = 
			"select a.id, a.nombre, c.nombre as categoria, a.precio " +
			"from articulo a left join categoria c " +
			"on a.categoria = c.id ";
		
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
		
		string[] columnNames = getColumnNames(mySqlDataReader);
		
		appendColumns(columnNames);
		
		ListStore listStore = createListStore(mySqlDataReader.FieldCount);

		while (mySqlDataReader.Read ()) {
			List<string> values = new List<string>();
			for (int index = 0; index < mySqlDataReader.FieldCount; index++)
				values.Add ( mySqlDataReader.GetValue (index).ToString() );
			listStore.AppendValues(values.ToArray());
		}
		mySqlDataReader.Close ();
		
		treeView.Model = listStore;
	}
	
	private string[] getColumnNames(MySqlDataReader mySqlDataReader) {
		List<string> columnNames = new List<string>();
		for (int index = 0; index < mySqlDataReader.FieldCount; index++)
			columnNames.Add (mySqlDataReader.GetName (index));
		return columnNames.ToArray ();
	}
	
	private void appendColumns(string[] columnNames) {
		int index = 0;
		foreach (string columnName in columnNames) 
			treeView.AppendColumn (columnName, new CellRendererText(), "text", index++);
	}
	
	private ListStore createListStore(int fieldCount) {
		Type[] types = new Type[fieldCount];
		for (int index = 0; index < fieldCount; index++)
			types[index] = typeof(string);
		return new ListStore(types);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
		
		mySqlConnection.Close ();
	}
}
