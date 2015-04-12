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

        public int Id { get; set; }
        public string RoleTitle { get; set; }
        public string abrv { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
