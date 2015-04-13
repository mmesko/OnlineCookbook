using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class UserRolePOCO : IUserRole
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual RolePOCO Role { get; set; }
        public virtual UserPOCO User { get; set; }
    }
}
