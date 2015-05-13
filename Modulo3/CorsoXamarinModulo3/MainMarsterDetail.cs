using System;

using Xamarin.Forms;

namespace CorsoXamarin
{
	public class MainMarsterDetail : MasterDetailPage
	{
		LoginPage _loginpage;
		MenuPage _menupage;

		public MainMarsterDetail ()
		{
			_menupage = new MenuPage ();;

			Master = _menupage;
			Detail = new DetailPage ();

			_loginpage = new LoginPage ();

			_menupage.ItemSelectedEvent += _menupage_ItemSelectedEvent;
		}

		void _menupage_ItemSelectedEvent (int idVoceDiMenu)
		{
			switch (idVoceDiMenu) 
			{
			case 1:
				Detail = new NavigationPage(new DetailPage ());
					IsPresented = false;
				break;
				default:
				case 2:
					Detail = new SecondaPagina ();
					IsPresented = false;
				break;
			}
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


