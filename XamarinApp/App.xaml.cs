using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Helpers;
using XamarinApp.Models;
using XamarinApp.Resources;
using XamarinApp.Services;
using XamarinApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinApp
{
    public partial class App : Application
    {
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            AppResources.Culture = new CultureInfo(Settings.culture);

            if (!Current.Properties.ContainsKey("chats"))
            {
                Current.Properties["chats"] = new ObservableCollection<AllChatsModel>();
            }

            Settings.GroupId = 1;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
