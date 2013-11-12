using System;

namespace Serpis.Ad
{
	public interface IEntityListView
	{
		void New();
		void Edit();
		void Delete();
		void Refresh();
		bool HasSelected {get;}
		event EventHandler SelectedChanged;
	}
}

