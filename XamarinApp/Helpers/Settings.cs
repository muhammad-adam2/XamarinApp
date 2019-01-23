using System;
using System.Globalization;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using XamarinApp.Models;

namespace XamarinApp.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string culture
        {
            get
            {
                return AppSettings.GetValueOrDefault("Culture", "en-ZA");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Culture", value);
            }
        }

        public static int GroupId
        {
            get
            {
                return AppSettings.GetValueOrDefault("group", 0);
            }
            set
            {
                AppSettings.AddOrUpdateValue("group", value);
            }
        }
    }
}
