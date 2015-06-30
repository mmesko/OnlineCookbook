using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class IdentityUserRole
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }
        public virtual User User { get; set; }
    }
}
