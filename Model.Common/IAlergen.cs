using System;
using System.Collections.Generic;


namespace OnlineCookbook.Model.Common
{
    public interface IAlergen
    {

        System.Guid Id { get; set; }
        string AlergenName { get; set; }
        System.Guid Abrv { get; set; }
        ICollection<IRecipeAlergen> RecipeAlergens { get; set; }
    }
}

