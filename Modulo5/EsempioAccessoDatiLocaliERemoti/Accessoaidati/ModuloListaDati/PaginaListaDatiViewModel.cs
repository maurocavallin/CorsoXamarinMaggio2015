using System;

using Xamarin.Forms;
using System.Collections.Generic;
using ClassLibrary1;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Accessoaidati
{
	public class PaginalistaDatiViewModel : NotifyPropertyChangedViewModel
	{
		public PaginalistaDatiViewModel ()
		{
			 
		}

		public async void LoadDati()
		{
			List<TodoItem> modelItems = new List<TodoItem> ();

			WebApiProxyService waps = new WebApiProxyService ();


			IsBusy = true;
			try
			{

				await Task.Delay(2000);

				var remoteItems = await waps.GetItemsAsync ();

				foreach(var remoteItem in remoteItems)
				{
					modelItems.Add(new TodoItem() {
						Name = remoteItem.Valore,   
					});
				}

				Dati = new ObservableCollection<TodoItem>(modelItems);
			}
			catch(Exception ex)
			{
				// Forms.DisplayAlert("", ex.Message, "OK");
			}
			finally {
				IsBusy = false;
			}
 
		}

		private ObservableCollection<TodoItem> _dati = null;
		public ObservableCollection<TodoItem> Dati
		{
			get
			{
				return _dati;
			}
			set
			{
				_dati = value;
				OnPropertyChanged ();
			}
		}
	}
}


