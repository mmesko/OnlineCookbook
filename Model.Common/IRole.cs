using System;


namespace OnlineCookbook.Model.Common
{
    public interface IRole
    {
         int Id { get; set; }
         string RoleTitle { get; set; }
         string abrv { get; set; }
    }
}
