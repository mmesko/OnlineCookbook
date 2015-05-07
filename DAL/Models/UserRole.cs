using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class UserRole
    {
        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
