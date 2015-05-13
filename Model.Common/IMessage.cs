using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IMessage
    {
        Guid Id { get; set; }
        string TextMessage { get; set; }
        DateTime DateCreated { get; set; }
        ICollection<IMessageUser> MessageUsers { get; set; }
    }
}

