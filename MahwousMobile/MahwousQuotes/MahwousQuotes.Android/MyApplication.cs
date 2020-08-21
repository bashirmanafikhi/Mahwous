using System;
using Android.App;
using Android.Runtime;
using Shiny;

namespace LocalNotificationsSample.Droid
{
    [Application]
    public class MyApplication : Application
    {
        public MyApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            AndroidShinyHost.Init(this, platformBuild: services => services.UseNotifications());
            Shiny.Notifications.AndroidOptions.DefaultSmallIconResourceName = "icon.png";
        }
    }
}