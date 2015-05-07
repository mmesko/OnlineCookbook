using System;

namespace OnlineCookbook.Model.Common
{
    public interface IUser
    {
        Guid Id { get; set; }
        string FullName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string SaltKey { get; set; }
        string RecoweryQuestion { get; set; }
        string RecoveryAnswer { get; set; }
    }
}
