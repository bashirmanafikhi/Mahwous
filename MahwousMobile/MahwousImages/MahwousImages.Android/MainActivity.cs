using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Gms.Ads;
using Android.Content;
using Plugin.LocalNotification;
using AndroidX.Work;

namespace MahwousImages.Droid
{
    [Activity(Label = "صور", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");


            // Must create a Notification Channel when API >= 26
            // you can created multiple Notification Channels with different names.
            NotificationCenter.CreateNotificationChannel();



            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


            LoadApplication(new App());


            //Forece app to run as RTL
            Window.DecorView.LayoutDirection = LayoutDirection.Rtl;

            // set statusbar color
            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 30, 30, 31));

            //NotificationCenter.NotifyNotificationTapped(Intent);

            // Notification Service Worker
            PeriodicWorkRequest notificationWorkRequest = PeriodicWorkRequest.Builder.From<NotificationWorker>(TimeSpan.FromMinutes(15)).Build();

            WorkManager.GetInstance(Application.Context).Enqueue(notificationWorkRequest);

        }

        protected override void OnNewIntent(Intent intent)
        {
            //NotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}