using System;


namespace OnlineCookbook.Model.Common
{
    public interface IMessage
    {

        int Id { get; set; }
        string TextMessage { get; set; }
        System.DateTime DateCreated { get; set; }
    }
}

