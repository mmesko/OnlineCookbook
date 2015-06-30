using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class MessageUser
    {
        public string Id { get; set; }
        public string MessageId { get; set; }
        public string UserId { get; set; }
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}
