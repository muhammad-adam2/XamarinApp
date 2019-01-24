using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace XamarinApp.MobileAppService.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageGroup(string groupName, string user, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
