using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace CookieBasedAuthExample.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }
        public async Task SendMessages(string fromuser, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", fromuser, message);
        }

        static Dictionary<string, string> clientIds = new Dictionary<string, string>();

        /// <summary>
        /// Registering the user
        /// </summary>
        /// <param name="user">User Name</param>
        /// <returns></returns>
        public async Task RegisterAsync(string user)
        {
            if (user is null)
                throw new NullReferenceException("Username is required");
            string message = "";
            if (!clientIds.ContainsKey(user))
            {
                clientIds.Add(user, Context.ConnectionId);
                message = "New user has joined into the group, say hello to " + user;
            }
            else
            {
                clientIds[user] = Context.ConnectionId;
                message = user + " Joined again";
            }

            await Clients.All.SendAsync("NewUserRegistred", message, clientIds.Keys.ToList());
        }


        public async Task SendMessageTo(string fromuser,string toUser ,string message)
        {
            await Clients.Client(clientIds[toUser]).SendAsync("ReceiveMessage", fromuser, message);
        }
    }
}
