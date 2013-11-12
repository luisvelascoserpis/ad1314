using System;
using Gtk;

using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		mainButton.Sensitive = false;

		ArticuloListView articuloListView = new ArticuloListView();
		CategoriaListView categoriaListView = new CategoriaListView();
		
		notebook.AppendPage ( articuloListView, new Label("Articulos"));
		notebook.AppendPage ( categoriaListView, new Label("Categorias"));
		
		notebook.SwitchPage += delegate {
			IEntityListView entityListView = (IEntityListView)notebook.CurrentPageWidget;
			mainButton.Sensitive = entityListView.HasSelected;
		};
		
		articuloListView.SelectedChanged += delegate {
			mainButton.Sensitive = articuloListView.HasSelected;
		};
		
		categoriaListView.SelectedChanged += delegate {
			mainButton.Sensitive = categoriaListView.HasSelected;
		};
		
		mainButton.Clicked += delegate {
			IEntityListView entityListView = (IEntityListView)notebook.CurrentPageWidget;
			entityListView.Edit ();
		};
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
