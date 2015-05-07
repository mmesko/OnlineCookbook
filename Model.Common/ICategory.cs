using System;

namespace OnlineCookbook.Model.Common
{
   public interface ICategory
    {
        Guid Id { get; set; }
        string CategoryName { get; set; }
        Guid Abrv { get; set; }

    }
}
