using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IIngradient
    {
         string Id { get; set; }
         string IngradientName { get; set; }
         string Abrv { get; set; }
         ICollection<IRecipeIngradient> RecipeIngradients { get; set; }
    }
}