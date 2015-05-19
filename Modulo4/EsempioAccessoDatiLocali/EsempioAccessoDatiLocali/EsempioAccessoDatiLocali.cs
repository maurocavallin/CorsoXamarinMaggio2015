using System;

using Xamarin.Forms;

namespace EsempioAccessoDatiLocali
{
	public class App : Application
	{
		// http://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/
		// https://github.com/xamarin/mobile-samples/tree/master/DataAccess

		// http://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_2_configuration/

		static TodoItemDatabase database;

		public static TodoItemDatabase Database {
			get { 
				if (database == null) {
					database = new TodoItemDatabase ();
				}
				return database; 
			}
		}


		public App ()
		{
			// The root page of your application
			MainPage = new PaginaMenuPrincipale();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

