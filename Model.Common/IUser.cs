using System;


namespace OnlineCookbook.Model.Common
{
    public interface IUser
    {
        int Id { get; set; }
        string FullName { get; set; }
        string username { get; set; }
        string password { get; set; }
        string SaltKey { get; set; }
        string RecoweryQuestion { get; set; }
        string RecoveryAnswer { get; set; }
    }
}
