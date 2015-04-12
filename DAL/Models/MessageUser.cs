using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class MessageUser
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public virtual Message Message { get; set; }
        public virtual User User { get; set; }
    }
}
