
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MahwousQuotes.Droid
{
    [Activity(Theme = "@style/SplashTheme",
                 MainLauncher = true,
                 NoHistory = true,
                 ConfigurationChanges = ConfigChanges.ScreenSize| ConfigChanges.Orientation | ConfigChanges.UiMode)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));
        }
    }
}