using Gtk;
using System;

namespace Serpis.Ad
{
	public class CategoriaListView : EntityListView
	{
		public CategoriaListView ()
		{
			treeView.AppendColumn("id", new CellRendererText(), "text", 0);
			treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
			
			ListStore listStore = new ListStore(typeof(int), typeof(string));
			listStore.AppendValues(1, "Categoría 1");
			listStore.AppendValues(2, "Categoría 2");
			listStore.AppendValues(3, "Categoría 3");
			
			treeView.Model = listStore;
		}

	}
}

