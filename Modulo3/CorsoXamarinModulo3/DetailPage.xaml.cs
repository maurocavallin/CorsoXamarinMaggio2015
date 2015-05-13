using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Lotz.Xam.Messaging;

namespace CorsoXamarin
{
	public partial class DetailPage : ContentPage
	{
		DetailPageViewModel _viewModel;

		public DetailPage ()
		{
			InitializeComponent ();
			BackgroundColor = Color.Gray;

			this.Title = "Applicazione";


			_viewModel = new DetailPageViewModel ();
			this.BindingContext = _viewModel;

			//var cell = new DataTemplate (typeof(ImageCell));
			//cell.SetBinding (TextCell.TextProperty, "Titolo");
			//cell.SetBinding (TextCell.DetailProperty, "Descrizione");
			//ListaPrincipale.ItemTemplate = cell;

			ListaPrincipale.SetBinding<MenuPageViewModel> (ListView.ItemsSourceProperty, c => c.Lista, BindingMode.OneWay);

			this.ListaPrincipale.RowHeight = 35; 
			this.ListaPrincipale.ItemTemplate = new DataTemplate(typeof(DetailPageCustomViewCell));

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

	public class DetailPageCustomViewCell : ViewCell
	{
		public DetailPageCustomViewCell ()
		{
			Button pulsante = new Button ();
			pulsante.Text = "Sel";

			pulsante.Clicked += (object sender, EventArgs e) => {

				int a = 2; 

				var smsTask = MessagingPlugin.SmsMessenger;
				if (smsTask.CanSendSms)
					smsTask.SendSms("+27213894839493", "Well hello there from Xam.Messaging.Plugin");
			};

			Image immagine = new Image ();
			immagine.Source = "icon.png";

			var primaryText = new Label()
			{
				HorizontalOptions= LayoutOptions.Fill,
				TextColor = Color.White,  
				YAlign = TextAlignment.Center, 
			}; 
			primaryText.SetBinding(Label.TextProperty, "Titolo");

			StackLayout contenitore = new StackLayout () {
				Orientation = StackOrientation.Horizontal,
				Children = { immagine, primaryText, pulsante }
			};

			  
			View = contenitore;
		}
	}


	public class DetailPageViewModel : NotifyPropertyChangedViewModel
	{
		public DetailPageViewModel ()
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

