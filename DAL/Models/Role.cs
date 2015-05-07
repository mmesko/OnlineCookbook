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

        public System.Guid Id { get; set; }
        public string RoleTitle { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
