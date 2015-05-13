using System;

using Xamarin.Forms;
using Refractored.Xam.Settings.Abstractions;
using Refractored.Xam.Settings;

namespace CorsoXamarin
{
	public class App : Application
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		private const string UserNameKey = "username_key";
		private static readonly string UserNameDefault = string.Empty;

		private const string SomeIntKey = "int_key";
		private static readonly int SomeIntDefault = 6251986;

		public static string UserName
		{
			get { return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault); }
			set { AppSettings.AddOrUpdateValue(UserNameKey, value); }
		}

		public static int SomeInt
		{
			get { return AppSettings.GetValueOrDefault(SomeIntKey, SomeIntDefault); }
			set { AppSettings.AddOrUpdateValue(SomeIntKey, value); }
		}

		public App ()
		{ 
			var useraname = UserName;
			UserName = "Mauro";


			// The root page of your application
			MainMarsterDetail m = new MainMarsterDetail();
			MainPage = m;


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

	public static class Settings
	{
		
	}
}

