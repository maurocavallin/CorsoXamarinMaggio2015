using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace CorsoXamarin
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();

			LoginButton.BackgroundColor = Color.Gray;


			LoginButton.Clicked += async delegate(object sender, EventArgs e) {
				 await LoginButton_Clicked();
			};
		}

		public bool SeLoggato { get; set; }

	 protected override void OnAppearing ()
		{
			base.OnAppearing ();
		}

		private async Task LoginButton_Clicked ()
		{

			string username = EntryUserName.Text;
			string password = EntryUserPassword.Text;
 
			// DisplayAlert ("Errore", "Dati non validi: " + username + " " + password, "OK");


			if (string.IsNullOrEmpty (username) || string.IsNullOrEmpty (password)) {

				await DisplayActionSheet ("Dati non validi: " + username + " " + password, "Annulla", "Destroy",
					new string[] { "pulsante1", "pulsante 2", "pulsante 3" });

				return;
			}
		
			SeLoggato = true;
			await Navigation.PopModalAsync();


		}
	}
}

