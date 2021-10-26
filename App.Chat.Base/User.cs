using System;
using System.Collections.ObjectModel;

namespace App.Chat.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; } = "../_img/ChatBG.png";
        public Guid Key { get; set; }
        public DateTime ConnectionOn { get; set; }

        public ObservableCollection<Message> Messages { get; set; } 
            = new ObservableCollection<Message>();
    }
}
