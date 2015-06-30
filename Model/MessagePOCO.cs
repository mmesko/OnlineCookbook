using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class MessagePOCO : IMessage
    {

        public MessagePOCO()
        {
            this.MessageUsers = new List<IMessageUser>();
        }
        public string Id { get; set; }
        public string TextMessage { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual ICollection<IMessageUser> MessageUsers { get; set; }
    }
}
