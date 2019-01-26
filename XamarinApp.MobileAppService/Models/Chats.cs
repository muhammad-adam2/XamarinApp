using System;
using System.Collections.Generic;

namespace XamarinApp.MobileAppService.Models
{
    public partial class Chats
    {
        public long ChatId { get; set; }
        public long GroupId { get; set; }
        public string ChatMessages { get; set; }
    }
}
