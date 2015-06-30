using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class MessageUserPOCO : IMessageUser
    {

        public string Id { get; set; }
        public string MessageId { get; set; }
        public string UserId { get; set; }
        public virtual IMessage Message { get; set; }
        public virtual IUser User { get; set; }

    }
}
