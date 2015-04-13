﻿using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class MessagePOCO : IMessage
    {

        public MessagePOCO()
        {
            this.MessageUsers = new List<MessageUserPOCO>();
        }

        public int Id { get; set; }
        public string TextMessage { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual ICollection<MessageUserPOCO> MessageUsers { get; set; }

    }
}
