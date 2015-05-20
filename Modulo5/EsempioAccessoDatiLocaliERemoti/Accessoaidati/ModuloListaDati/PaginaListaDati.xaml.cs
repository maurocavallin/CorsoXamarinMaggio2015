using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Accessoaidati
{
	public partial class PaginaListaDati : ContentPage
	{
		PaginalistaDatiViewModel _viewModel = null;

		public PaginaListaDati ()
		{
			InitializeComponent ();

			Title = "Lista dati";

			_viewModel = DependencyService.Get<PaginalistaDatiViewModel> ();
 
			this.BindingContext = _viewModel;

			/*
			var cell = new DataTemplate (typeof(TextCell));
			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetBinding (TextCell.DetailProperty, "Name");
			MainListView.ItemTemplate = cell;
			*/

			// this.MainListView.RowHeight = ; 
			this.MainListView.ItemTemplate = new DataTemplate(typeof(CustomCell));
			this.MainListView.RowHeight = Device.OnPlatform(50, 50, 50);

			MainListView.SetBinding<PaginalistaDatiViewModel> (ListView.ItemsSourceProperty, c => c.Dati, BindingMode.OneWay);
			Clessidra.SetBinding<PaginalistaDatiViewModel> (ActivityIndicator.IsVisibleProperty, c => c.IsBusy, BindingMode.OneWay);

			// definizione della griglia e binding

			Clessidra.IsRunning = true;

			Ricerca.SearchButtonPressed += async (object sender, EventArgs e) => {
				_viewModel.LoadDati ();
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			_viewModel.LoadDati ();
		}


	}
}

