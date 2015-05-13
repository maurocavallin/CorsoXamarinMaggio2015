﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using CorsoXamarin;

namespace CorsoXamarinModulo3.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
		

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}
