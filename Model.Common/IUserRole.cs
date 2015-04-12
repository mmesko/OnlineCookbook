using System;


namespace OnlineCookbook.Model.Common
{
   public interface IUserRole
    {

         int Id { get; set; }
         int UserId { get; set; }
         int RoleId { get; set; }
        //public virtual Role Role { get; set; }
        //public virtual User User { get; set; }
    }
}
