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
	

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			List<MioOggetto> listaValori = new List<MioOggetto> () {

				new MioOggetto () { Titolo = "Ritolo", Descrizione = "descriz." },
				new MioOggetto () { Titolo = "Ritolo", Descrizione = "descriz." },
				new MioOggetto () { Titolo = "Ritolo", Descrizione = "descriz." },
				new MioOggetto () { Titolo = "Ritolo", Descrizione = "descriz." },
			};

			_viewModel.Lista = listaValori;
		}
	}



	public class MioOggetto
	{
		public string Titolo { get; set; }
		public string Descrizione { get; set; }
	}

	public class MenuPageViewModel : NotifyPropertyChangedViewModel
	{
		public MenuPageViewModel ()
		{
			_lista = new List<MioOggetto> ();
		}

		private List<MioOggetto> _lista;
		public List<MioOggetto> Lista 
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

