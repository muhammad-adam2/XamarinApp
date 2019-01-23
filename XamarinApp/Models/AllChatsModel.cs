using System;
using System.Collections.ObjectModel;

namespace XamarinApp.Models
{
    public class AllChatsModel
    {
        public int ChatId { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
    }
}
