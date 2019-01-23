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
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<MessageModel> DelayedMessages { get; set; } = new Queue<MessageModel>();
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        private ObservableCollection<AllChatsModel> AllChats { get; set; } = new ObservableCollection<AllChatsModel>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }
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

            AllChats = Application.Current.Properties["chats"] as ObservableCollection<AllChatsModel>;

            if (AllChats.Any(x => x.ChatId == Settings.GroupId))
            {
                AllChatsModel model = AllChats.Single(x => x.ChatId == Settings.GroupId);
                Messages = model.Messages;
            }
            else
            {
                AllChats.Add(new AllChatsModel
                {
                    ChatId = Settings.GroupId,
                    Messages = new ObservableCollection<MessageModel>()
                });
            }

            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var finalMessage = message;
                // Update the UI
                Messages.Add(new MessageModel { Message = message, User = user });
            });
            //Messages.Add(new MessageModel() { Message = "Hi", User = "user 2" });
            //Messages.Add(new MessageModel() { Message = "How are you", User = "user 1" });

            //MessageAppearingCommand = new Command<MessageModel>(OnMessageAppearing);
            //MessageDisappearingCommand = new Command<MessageModel>(OnMessageDisappearing);

            OnSendCommand = new Command(async () =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Add(new MessageModel() { Message = TextToSend, User = "user 1" });
                    AllChatsModel model = AllChats.Single(x => x.ChatId == Settings.GroupId);
                    model.Messages = Messages;
                    await Connect();

                    await SendMessage("user 1",TextToSend);
                    TextToSend = string.Empty;
                }

            });

            //Code to simulate reveing a new message procces
            //Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            //{
            //    if (LastMessageVisible)
            //    {
            //        Messages.Insert(0, new MessageModel() { Message = "New message test", User = "Mario" });
            //    }
            //    else
            //    {
            //        DelayedMessages.Enqueue(new MessageModel() { Message = "New message test", User = "Mario" });
            //        PendingMessageCount++;
            //    }
            //    return true;
            //});
        }

        async Task Connect()
        {
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task SendMessage(string user, string message)
        {
            try
            {
                await hubConnection.InvokeAsync("SendMessage", user, message);
            }
            catch (Exception ex)
            {
                throw;
                // send failed
            }
        }

        //void OnMessageAppearing(MessageModel message)
        //{
        //    var idx = Messages.IndexOf(message);
        //    if (idx <= 6)
        //    {
        //        Device.BeginInvokeOnMainThread(() =>
        //        {
        //            while (DelayedMessages.Count > 0)
        //            {
        //                Messages.Insert(0, DelayedMessages.Dequeue());
        //            }
        //            ShowScrollTap = false;
        //            LastMessageVisible = true;
        //            PendingMessageCount = 0;
        //        });
        //    }
        //}

        //void OnMessageDisappearing(MessageModel message)
        //{
        //    var idx = Messages.IndexOf(message);
        //    if (idx >= 6)
        //    {
        //        Device.BeginInvokeOnMainThread(() =>
        //        {
        //            ShowScrollTap = true;
        //            LastMessageVisible = false;
        //        });
        //
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
