using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Role
    {
        public Role()
        {
            this.UserRoles = new List<UserRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
