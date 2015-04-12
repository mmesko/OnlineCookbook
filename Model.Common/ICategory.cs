using System;

namespace OnlineCookbook.Model.Common
{
   public interface ICategory
    {
         int Id { get; set; }
         string CategoryName { get; set; }
         string abrv { get; set; }

    }
}
