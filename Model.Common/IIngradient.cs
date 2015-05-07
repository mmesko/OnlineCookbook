using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IIngradient
    {
         Guid Id { get; set; }
         string IngradientName { get; set; }
         Guid Abrv { get; set; }
         ICollection<IRecipeIngradient> RecipeIngradients { get; set; }
    }
}