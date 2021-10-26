using System;

namespace App.Chat.Models
{
    public class Message : BaseModel
    {
        public Guid Destination { get; set; }
        public User Sender { get; set; }
        public string Content { get; set; }
    }
}
