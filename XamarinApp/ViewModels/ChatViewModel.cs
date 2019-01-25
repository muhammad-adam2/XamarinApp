using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;
using XamarinApp.Helpers;
using XamarinApp.Models;

namespace XamarinApp.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        private ObservableCollection<AllChatsModel> AllChats { get; set; } = new ObservableCollection<AllChatsModel>();
        public string TextToSend { get; set; }
        public string errormessage { get; set; }
        public bool isConnected { get; set; }

        HubConnection hubConnection;

        private static AllChatsModel defaultchat
        {
            get
            {
                return new AllChatsModel();
            }
        }

        public ChatViewModel()
        {
            // localhost for UWP/iOS or special IP for Android
            var ip = "localhost";
            if (Device.RuntimePlatform == Device.Android)
                ip = "10.0.2.2";

            hubConnection = new HubConnectionBuilder()
                .WithUrl($"http://{ip}:5000/chathub")
                .Build();

            //AllChats = Application.Current.Properties["chats"] as ObservableCollection<AllChatsModel>;

            //if (AllChats.Any(x => x.ChatId == Settings.GroupId))
            //{
            //    AllChatsModel model = AllChats.Single(x => x.ChatId == Settings.GroupId);
            //    Messages = model.Messages;
            //}
            //else
            //{
            //    AllChats.Add(new AllChatsModel
            //    {
            //        ChatId = Settings.GroupId,
            //        Messages = new ObservableCollection<MessageModel>()
            //    });
            //}
            

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            { 
                var finalMessage = message;
                if (user != Settings.User)
                {
                    Messages.Add(new MessageModel { Message = message, User = user });
                }
                else
                    return;
            });

        }

        public ICommand OnSendCommand => new Command(() =>
            {
            if (!string.IsNullOrEmpty(TextToSend))
            {
                Messages.Add(new MessageModel() { Message = TextToSend, User = Settings.User });
                //AllChatsModel model = AllChats.Single(x => x.ChatId == Settings.GroupId);
                //model.Messages = Messages;
                Connect();
                SendMessage(Settings.User, TextToSend);
                TextToSend = string.Empty;
            }

        });

        void Connect()
        {
            if (isConnected)
                return;

            try
            {
                hubConnection.StartAsync();
                hubConnection.InvokeAsync("AddToGroup", Settings.GroupName, Settings.User);
                isConnected = true;
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                throw;
            }
        }

        void SendMessage(string user, string message)
        {
            try
            {
                hubConnection.InvokeAsync("SendMessageGroup", Settings.GroupName, user, message);
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                throw;
                // send failed
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
