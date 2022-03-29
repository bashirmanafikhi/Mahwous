using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Appsflyer;

namespace Mahwous.Droid
{
    [Activity(Label = "مهووس", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize| ConfigChanges.Orientation | ConfigChanges.UiMode)]
    public class MainActivity : MobileBase.Android.MainActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppsFlyerLib.Instance.Init("amDSrit2yhKZEiaE5SWmNn", null, this.Application);
            AppsFlyerLib.Instance.Start(this.Application, "amDSrit2yhKZEiaE5SWmNn");

            LoadApplication(new App());
        }
    }
}