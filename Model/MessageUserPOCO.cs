﻿using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class MessageUserPOCO : IMessageUser
    {

        public System.Guid Id { get; set; }
        public System.Guid MessageId { get; set; }
        public System.Guid UserId { get; set; }
        public virtual IMessage Message { get; set; }
        public virtual IUser User { get; set; }

    }
}
