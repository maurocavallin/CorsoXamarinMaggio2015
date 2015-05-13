using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.ComponentModel;

namespace CorsoXamarin
{
	public partial class MenuPage : ContentPage
	{
		MenuPageViewModel _viewModel = null;

		public MenuPage ()
		{
			InitializeComponent ();
			BackgroundColor = Color.Aqua;

			this.Title = "Menu";

			_viewModel = new MenuPageViewModel ();
			this.BindingContext = _viewModel;

			var cell = new DataTemplate (typeof(ImageCell));
			cell.SetBinding (TextCell.TextProperty, "Titolo");
			cell.SetBinding (TextCell.DetailProperty, "Descrizione");
			ListaVociMenu.ItemTemplate = cell;

			ListaVociMenu.SetBinding<MenuPageViewModel> (ListView.ItemsSourceProperty, c => c.Lista, BindingMode.OneWay);
	
			ListaVociMenu.ItemSelected += async (sender, e) => {

				if (e.SelectedItem == null) return; 

				var elementoSelezionato = (VoceDiMenu)e.SelectedItem;

				await DisplayAlert("selezione lista",
					"hai selezionato la voce" + elementoSelezionato.IdVoceDiMenu, "OK");
 
			};
		}



		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			List<VoceDiMenu> listaValori = new List<VoceDiMenu> () {

				new VoceDiMenu () { IdVoceDiMenu = 1, Titolo = "Sezione1", Descrizione = "Sezione1" },
				new VoceDiMenu () { IdVoceDiMenu = 2, Titolo = "Sezione2", Descrizione = "Sezione2" },
				new VoceDiMenu () { IdVoceDiMenu = 3, Titolo = "Sezione3", Descrizione = "Sezione3" },
				new VoceDiMenu () { IdVoceDiMenu = 4, Titolo = "Sezione4", Descrizione = "Sezione4" },
			};

			_viewModel.Lista = listaValori;
		}
	}



	public class VoceDiMenu
	{
		public int IdVoceDiMenu { get; set;}
		public string Titolo { get; set; }
		public string Descrizione { get; set; }
	}

	public class MenuPageViewModel : NotifyPropertyChangedViewModel
	{
		public MenuPageViewModel ()
		{
			_lista = new List<VoceDiMenu> ();
		}

		private List<VoceDiMenu> _lista;
		public List<VoceDiMenu> Lista 
		{ 
			get
			{ 
				return _lista;
			}
			set
			{ 
				_lista = value;
				OnPropertyChanged ();
			} 
		}

	}
}

