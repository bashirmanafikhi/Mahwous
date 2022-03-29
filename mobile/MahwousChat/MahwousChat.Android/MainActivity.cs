﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MahwousChat.Droid
{
    [Activity(Label = "دردشة مهووس", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize| ConfigChanges.Orientation | ConfigChanges.UiMode)]
    public class MainActivity : MobileBase.Android.MainActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LoadApplication(new App());
        }

    }
}