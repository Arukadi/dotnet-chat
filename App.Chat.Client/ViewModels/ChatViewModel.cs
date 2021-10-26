using App.Chat.Client;
using App.Chat.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace App.Chat.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        #region Private Properties

        private const int DELAY_TO_CLOSE_NOTIFY = 4000;

        private HubConnection conn;
        private List<Guid> auxUsers;

        #endregion

        #region Constructor

        public ChatViewModel()
        {
            Users = new ObservableCollection<User>();
            auxUsers = new List<Guid>();
        }

        #endregion

        #region Public Properties

        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public User CurrentUser
        {
            get => ChatApp.CurrentUser;
            set => ChatApp.CurrentUser = value;
        }
        public string ChatBackground
        {
            get => ChatApp.ChatBackground;
            set => ChatApp.ChatBackground = value;
        }
        public object ChatConfig { get; set; }

        public double NotifyLeft { get; set; } = 0;
        public double NotifyTop { get; set; } = 0;

        #endregion

        #region Methods()

        public async Task<bool> LoadUser(User user)
        {
            CurrentUser = user;
            return await StartConnection(user);
        }

        private Task<bool> StartConnection(User user)
        {
            try
            {
                conn = new HubConnectionBuilder()
                .WithUrl($"http://localhost:5000/chat?user={JsonConvert.SerializeObject(user)}")
                .Build();

                conn.StartAsync();

                conn.Closed += async (error) =>
                {
                    await conn.StartAsync();
                };

                VerifyUsersConnection();
                ReceiveMessage();
            }
            catch
            {
                Task.Delay(5000);
                StartConnection(user);
            }

            return Task.FromResult(true);
        }

        private void VerifyUsersConnection() =>
            conn.On<List<User>, User, bool>("Chat", (users, user, onConnection) =>
            {
                if (onConnection)
                {
                    users.ForEach(row =>
                    {
                        if (row.Key != CurrentUser.Key && !auxUsers.Contains(row.Key))
                        {
                            Users.Add(row);
                            auxUsers.Add(row.Key);
                        }
                    });
                }
                else
                {
                    if (auxUsers.Contains(user.Key))
                    {
                        var removeUser = Users.Where(u => u.Key == user.Key).Select(u => u).FirstOrDefault();
                        Users.Remove(removeUser);
                        auxUsers.Remove(removeUser.Key);
                    }
                }
            });

        public void SendMessage(string content)
        {
            var m = new Message
            {
                Destination = SelectedUser.Key,
                Sender = CurrentUser,
                Content = content
            };

            SelectedUser.Messages.Add(m);
            conn.InvokeAsync("SendMessage", m);
        }

        private void ReceiveMessage() =>
            conn.On<User, string>("Receive", (sender, content) =>
            {
                var user = Users.Where(u => u.Key == sender.Key)
                                .Select(u => u)
                                .FirstOrDefault();

                var m = new Message
                {
                    Destination = CurrentUser.Key,
                    Sender = sender,
                    Content = content
                };
                user.Messages.Add(m);
            });

        private async void CallNotify(string title, string content)
        {
            var notify = new Notification(NotifyLeft, NotifyTop, title, content);
            notify.Show();

            await Task.Delay(DELAY_TO_CLOSE_NOTIFY);
            notify.Close();
        }

        #endregion
    }
}
