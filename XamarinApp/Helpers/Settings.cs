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

        public static string User
        {
            get
            {
                return AppSettings.GetValueOrDefault("User", "user 1");
            }
            set
            {
                AppSettings.AddOrUpdateValue("User", value);
            }
        }

        public static string GroupName
        {
            get
            {
                return AppSettings.GetValueOrDefault("GroupName", "1");
            }
            set
            {
                AppSettings.AddOrUpdateValue("GroupName", value);
            }
        }
    }
}
