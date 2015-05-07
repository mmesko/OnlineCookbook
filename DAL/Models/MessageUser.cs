using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class MessageUser
    {
        public System.Guid Id { get; set; }
        public System.Guid MessageId { get; set; }
        public System.Guid UserId { get; set; }
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}
