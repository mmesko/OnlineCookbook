using System;

namespace OnlineCookbook.Model.Common
{
    public interface IMessage
    {
        Guid Id { get; set; }
        string TextMessage { get; set; }
        DateTime DateCreated { get; set; }
    }
}

