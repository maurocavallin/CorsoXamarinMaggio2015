using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

using SQLite;

namespace EsempioAccessoDatiLocali
{
	public partial class PaginaMenuPrincipale : ContentPage
	{
		public PaginaMenuPrincipale ()
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

