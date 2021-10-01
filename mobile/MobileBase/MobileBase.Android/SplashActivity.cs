using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MobileBase.Android
{
    [Activity(Theme = "@style/SplashTheme",
                 MainLauncher = false,
                 NoHistory = true,
                 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //StartActivity(typeof(MainActivity));
        }
    }
}