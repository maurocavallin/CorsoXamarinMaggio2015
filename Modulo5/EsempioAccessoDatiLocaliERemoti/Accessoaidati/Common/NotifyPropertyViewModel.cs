using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Accessoaidati
{
	public class NotifyPropertyChangedViewModel : INotifyPropertyChanged
	{

		private DateTime _ultimaDataOraCaricamentoUTC = DateTime.UtcNow.AddYears(-1);

		protected void ImpostaDataOraUltimoCaricamento()
		{
			_ultimaDataOraCaricamentoUTC = DateTime.UtcNow;
		}

		protected void ResettaDataUltimoCaricamento()
		{
			_ultimaDataOraCaricamentoUTC = DateTime.UtcNow.AddYears(-1);
		}

		protected bool SeTempoTrascorsoDaUltimoCaricamento(int secondi)
		{
			var differenza = DateTime.UtcNow - _ultimaDataOraCaricamentoUTC;
			if (differenza.TotalSeconds > secondi) {
				return true;
			}

			return false;
		}

		private bool _isBusy = false;

		public bool IsBusy
		{
			get
			{
				return _isBusy;
			}
			set
			{
				if (_isBusy != value) {
					_isBusy = value;
					OnPropertyChanged ();
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

