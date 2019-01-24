using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            this.BindingContext = new ChatViewModel();
        }


        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }
    }
}
