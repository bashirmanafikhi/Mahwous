﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MahwousQuotes.Droid
{
    [Activity(Label = "مسجاتي", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MobileBase.Android.MainActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadApplication(new App());
        }

    }
}