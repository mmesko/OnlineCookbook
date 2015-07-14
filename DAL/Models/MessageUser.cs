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
        public virtual ICollection<User> Users { get; set; }
    }
}
