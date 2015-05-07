using System;

namespace OnlineCookbook.Model.Common
{
   public interface IUserRole
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
        Guid RoleId { get; set; }
    }
}
