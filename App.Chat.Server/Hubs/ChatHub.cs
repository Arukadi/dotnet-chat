using App.Chat.Models;
using App.Chat.Server.Repository;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace App.Chat.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionRepository connections = new ConnectionRepository();

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = connections.GetUserByKey(Context.ConnectionId);
            connections.Remove(Context.ConnectionId);
            Clients.All.SendAsync("Chat", connections.GetAllUsers(), user, false);

            return base.OnDisconnectedAsync(exception);
        }

        public override Task OnConnectedAsync()
        {
            var user = JsonConvert.DeserializeObject<User>(Context.GetHttpContext().Request.Query["user"]);
            connections.Add(Context.ConnectionId, user);

            Clients.All.SendAsync("Chat", connections.GetAllUsers(), user, true);

            return base.OnConnectedAsync();
        }

        public async Task SendMessage(Message message)
        {
            await Clients.Client(connections.GetUserId(message.Destination))
                         .SendAsync("Receive", message.Sender, message.Content);
        }
    }
}
