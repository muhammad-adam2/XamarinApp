using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinApp.ViewModels;

namespace XamarinApp.Views.Partials
{
    public partial class ChatInputBarView : ContentView
    {
        public ChatInputBarView()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                this.SetBinding(HeightRequestProperty, new Binding("Height", BindingMode.OneWay, null, null, null, chatTextInput));
            }
        }

        public void Handle_Completed(object sender, EventArgs e)
        {
            (this.Parent.Parent.BindingContext as ChatViewModel).OnSendCommand.Execute(null);
            chatTextInput.Unfocus();
        }

        public void UnFocusEntry()
        {
            chatTextInput?.Unfocus();
        }
    }
}
