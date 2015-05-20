using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;
using ClassLibrary1;
using System.Threading.Tasks;

namespace Accessoaidati
{
	public partial class MyPage : ContentPage
	{
		public MyPage ()
		{
			InitializeComponent ();

			this.PrimoPulsante.Text = "Conta Elementi";
			this.PrimoPulsante.Clicked +=  (object sender, EventArgs e) => {
				contaElementi();
			};

			this.SecondoPulsante.Text = "Inserisci Elementi";
			this.SecondoPulsante.Clicked += (object sender, EventArgs e) => {
				inserisciElemento();
			};

			this.TerzoPulsante.Text = "Elimina Un Elemento";
			this.TerzoPulsante.Clicked += (object sender, EventArgs e) => {
				eliminaElemento();
			};


			this.QuartoPulsante.Text = "Apri pagina";
			this.QuartoPulsante.Clicked += async (object sender, EventArgs e) => {
				Navigation.PushAsync(new PaginaListaDati());

			};

		}

		protected override async void OnAppearing ()
		{
			base.OnAppearing (); 
		}

		 

		private void customQuery()
		{
			var items = App.Database.GetItemsNotDone ().ToList();

			DisplayAlert ("", "Recuperati nro elementi: " + items.Count (), "OK");
		}

		private void contaElementi()
		{
			var items = App.Database.GetItems ().ToList();

			DisplayAlert ("", "Recuperati nro elementi: " + items.Count (), "OK");

		}

		private void inserisciElemento()
		{

			TodoItem td = new TodoItem (){ 
				ID = 0, // è nuovo da salvare
				Name = "NuovoItem" + DateTime.Now.Ticks,
				Notes = "NuovoItemNote" + DateTime.Now.Ticks
			};
			App.Database.SaveItem (td);

			contaElementi ();
		}

		private void eliminaElemento()
		{

			var itemToDelete = App.Database.GetItems ().FirstOrDefault ();

			if (itemToDelete != null) {
				App.Database.DeleteItem (itemToDelete.ID);	
			} else {
				DisplayAlert ("", "non ci sono elementi da cancellare ", "OK");
				return;
			}

			contaElementi ();
		}
	}
}

