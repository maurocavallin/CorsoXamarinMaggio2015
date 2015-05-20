using System;

using Xamarin.Forms;

namespace Accessoaidati
{
	public class App : Application
	{
		// public static ISQLite SqlLite;

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
			NavigationPage navPage = new NavigationPage(new MyPage());
			navPage.BarBackgroundColor = Color.Blue;
			MainPage = navPage;
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

