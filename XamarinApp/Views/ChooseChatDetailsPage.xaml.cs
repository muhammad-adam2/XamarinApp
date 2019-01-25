using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinApp.Helpers;

namespace XamarinApp.Views
{
    public partial class ChooseChatDetailsPage : ContentPage
    {
        public ChooseChatDetailsPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Settings.User = "user 1";
            Settings.GroupName = "1";
            DisplayAlert("details", Settings.GroupName + " " + Settings.User, "close");
            Navigation.PushAsync(new ChatPage());
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Settings.User = "user 2";
            Settings.GroupName = "1";
            DisplayAlert("details", Settings.GroupName + " " + Settings.User, "close");
            Navigation.PushAsync(new ChatPage());
        }

        void Handle_Clicked_2(object sender, System.EventArgs e)
        {
            Settings.User = "user 1";
            Settings.GroupName = "2";
            DisplayAlert("details", Settings.GroupName + " " + Settings.User, "close");
            Navigation.PushAsync(new ChatPage());
        }

        void Handle_Clicked_3(object sender, System.EventArgs e)
        {
            Settings.User = "user 2";
            Settings.GroupName = "2";
            DisplayAlert("details", Settings.GroupName + " " + Settings.User, "close");
            Navigation.PushAsync(new ChatPage());
        }
    }
}
