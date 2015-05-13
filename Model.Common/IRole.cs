using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IRole
    {
        Guid Id { get; set; }
        string RoleTitle { get; set; }
        Guid Abrv { get; set; }
        ICollection<IUserRole> UserRoles { get; set; }
    }
}
