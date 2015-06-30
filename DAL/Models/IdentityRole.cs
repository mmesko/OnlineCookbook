using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class IdentityRole
    {
        public IdentityRole()
        {
            this.IdentityUserRoles = new List<IdentityUserRole>();
        }

        public string Id { get; set; }
        public string RoleTitle { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<IdentityUserRole> IdentityUserRoles { get; set; }
    }
}
