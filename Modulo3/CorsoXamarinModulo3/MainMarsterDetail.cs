using System;

using Xamarin.Forms;

namespace CorsoXamarin
{
	public class MainMarsterDetail : MasterDetailPage
	{
		LoginPage _loginpage;

		public MainMarsterDetail ()
		{
			Master = new MenuPage ();
			Detail = new DetailPage ();

			_loginpage = new LoginPage ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!_loginpage.SeLoggato) {
				Navigation.PushModalAsync (_loginpage);
			}

			// il presented espande il menu laterale
			IsPresented = true;
		}
	}
}


