﻿using System;

namespace OnlineCookbook.Model.Common
{
    public interface IMessageUser
    {
        Guid Id { get; set; }
        Guid MessageId { get; set; }
        Guid UserId { get; set; }
    }
}