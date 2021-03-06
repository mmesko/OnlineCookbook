using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Message
    {
        public Message()
        {
            this.MessageUsers = new List<MessageUser>();
        }

        public string Id { get; set; }
        public string TextMessage { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual ICollection<MessageUser> MessageUsers { get; set; }
    }
}
