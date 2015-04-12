using System;


namespace OnlineCookbook.Model.Common
{
    public interface IMessageUser
    {
        int Id { get; set; }
        int MessageId { get; set; }
        int UserId { get; set; }
        // public virtual Message Message { get; set; }
        // public virtual User User { get; set; }

    }
}
