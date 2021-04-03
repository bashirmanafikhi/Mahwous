using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MahwousImages.Droid
{
    [Activity(Theme = "@style/SplashTheme",
                 MainLauncher = true,
                 NoHistory = true,
                 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));
        }
    }
}