using Gtk;
using MySql.Data.MySqlClient;
using System;

public partial class MainWindow: Gtk.Window
{	
	private MySqlConnection mySqlConnection;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		mySqlConnection = new MySqlConnection("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
		mySqlConnection.Open ();
		
		treeView.AppendColumn ("id", new CellRendererText(), "text", 0);
		treeView.AppendColumn ("nombre", new CellRendererText(), "text", 1);
		treeView.AppendColumn ("categoria", new CellRendererText(), "text", 2);
		treeView.AppendColumn ("precio", new CellRendererText(), "text", 3);
		
		int fieldCount = 4;
		Type[] types = new Type[fieldCount];
		for (int index = 0; index < fieldCount; index++)
			types[index] = typeof(string);
		
		//ListStore listStore = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
		ListStore listStore = new ListStore(types);
		//listStore.AppendValues ("1", "uno", "1", "1.5");
		string[] values = new string[]{"1", "uno", "1", "1.5"};
		listStore.AppendValues(values);
		
		listStore.AppendValues ("2", "dos");
		listStore.AppendValues ("3", "tres");
		
		treeView.Model = listStore;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
		
		mySqlConnection.Close ();
	}
}
