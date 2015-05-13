using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class UserRolePOCO : IUserRole
    {

        public System.Guid Id { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid RoleId { get; set; }
        public virtual IRole Role { get; set; }
        public virtual IUser User { get; set; }
    }
}
