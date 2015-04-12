using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RolePOCO : IRole
    {
        public RolePOCO()
        {
            //this.UserRoles = new List<UserRole>();
        }

        public int Id { get; set; }
        public string RoleTitle { get; set; }
        public string abrv { get; set; }
        //public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
