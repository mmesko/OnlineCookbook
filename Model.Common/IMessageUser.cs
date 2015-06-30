using System;

namespace OnlineCookbook.Model.Common
{
    public interface IMessageUser
    {
        string Id { get; set; }
        string MessageId { get; set; }
        string UserId { get; set; }
        IMessage Message { get; set; }
        IUser User { get; set; }
    }
}
