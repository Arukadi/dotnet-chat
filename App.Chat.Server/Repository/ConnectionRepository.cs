using App.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Chat.Server.Repository
{
    public class ConnectionRepository
    {
        private readonly Dictionary<string, User> connections = 
            new Dictionary<string, User>();

        public void Add(string uniqueId, User user)
        {
            if (!connections.ContainsKey(uniqueId))
                connections.Add(uniqueId, user);
        }

        public string GetUserId(Guid id) =>
            connections.Where(c => c.Value.Key == id)
                       .Select(c => c.Key)
                       .FirstOrDefault();

        public User GetUserByKey(string uniqueId) =>
            connections[uniqueId];

        public List<User> GetAllUsers() =>
            connections.Select(c => c.Value).ToList();

        public void Remove(string uniqueId)
        {
            if (connections.ContainsKey(uniqueId))
                connections.Remove(uniqueId);
        }
    }
}
