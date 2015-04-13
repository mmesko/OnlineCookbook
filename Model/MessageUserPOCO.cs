using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class MessageUserPOCO : IMessageUser
    {

        public int Id { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public virtual MessagePOCO Message { get; set; }
        public virtual UserPOCO User { get; set; }

    }
}
