﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using NightMates.Mobile.Droid.Configuration;

namespace NightMates.Mobile.Droid
{
    [Activity(Label = "NightMates.Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var bootstrapper = new AndroidBootstrapper();
            LoadApplication(new App(bootstrapper));
        }
    }
}