using Mahwous.Service.Repositories;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace MahwousMobile.Base.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private static readonly string SettingsDefault = string.Empty;
        public static readonly string TestInterstitialAdKey = "ca-app-pub-3940256099942544/1033173712";
        public static readonly string TestBannerAdKey = "ca-app-pub-3940256099942544/6300978111";
        public static readonly string TestRewardedAdKey = "ca-app-pub-3940256099942544/5224354917";

        #endregion

        public static string BannerAdKey
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(BannerAdKey), TestBannerAdKey);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(BannerAdKey), value);
            }
        }
        public static string RewardedAdKey
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(RewardedAdKey), TestRewardedAdKey);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(RewardedAdKey), value);
            }
        }

        public static string InterstitialAdKey
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(InterstitialAdKey), TestInterstitialAdKey);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(InterstitialAdKey), value);
            }
        }

        public static string AppTitle
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(AppTitle), "حالات مهووس");
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(AppTitle), value);
            }
        }

        public static string Token
        {
            get
            {
                return Xamarin.Essentials.SecureStorage.GetAsync(nameof(Token)).Result;
            }
            set
            {
                if (value == null)
                {
                    Xamarin.Essentials.SecureStorage.Remove(nameof(Token));
                    return;
                }
                DependencyService.Get<MahwousRepositories>().Token = value;
                Xamarin.Essentials.SecureStorage.SetAsync(nameof(Token), value);
            }
        }

        public static Shell MainShellWindow { get; set; }
    }
}
