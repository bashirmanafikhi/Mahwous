using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

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
                return AppSettings.GetValueOrDefault(nameof(Token), null);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(Token), value);
            }
        }
    }
}
