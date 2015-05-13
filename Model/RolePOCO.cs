using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RolePOCO : IRole
    {
        public RolePOCO()
        {
            this.UserRoles = new List<IUserRole>();
        }

        public System.Guid Id { get; set; }
        public string RoleTitle { get; set; }
        public System.Guid Abrv { get; set; }
        public virtual ICollection<IUserRole> UserRoles { get; set; }
    }
}
