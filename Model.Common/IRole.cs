﻿using System;

namespace OnlineCookbook.Model.Common
{
    public interface IRole
    {
        Guid Id { get; set; }
        string RoleTitle { get; set; }
        Guid Abrv { get; set; }
    }
}
