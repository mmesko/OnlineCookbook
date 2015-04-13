using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RolePOCO : IRole
    {
        public RolePOCO()
        {
            this.UserRoles = new List<UserRolePOCO>();
        }

        public int Id { get; set; }
        public string RoleTitle { get; set; }
        public string abrv { get; set; }
        public virtual ICollection<UserRolePOCO> UserRoles { get; set; }
    }
}
