using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Matcha.BackgroundService.Droid;
using Plugin.LocalNotification;
using Android.Content;
using Xamarin.Forms;
using Android.Gms.Ads;

namespace MahwousQuotes.Droid
{
    [Activity(Label = "مسجاتي", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Notification
            NotificationCenter.CreateNotificationChannel();

            //background service matcha
            BackgroundAggregator.Init(this);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //Forms.SetFlags("Brush_Experimental");


            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            MobileAds.Initialize(ApplicationContext, "ca-app-pub-1685177955120006~6067673223");

            LoadApplication(new App());



            //Forece app to run as RTL
            Window.DecorView.LayoutDirection = LayoutDirection.Rtl;

            // set statusbar color
            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 30, 30, 31));

            NotificationCenter.NotifyNotificationTapped(Intent);
        }


        protected override void OnNewIntent(Intent intent)
        {
            NotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}