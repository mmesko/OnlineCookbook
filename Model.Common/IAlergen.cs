using System;
using System.Collections.Generic;


namespace OnlineCookbook.Model.Common
{
    public interface IAlergen
    {

        string Id { get; set; }
        string AlergenName { get; set; }
        string Abrv { get; set; }
        ICollection<IRecipeAlergen> RecipeAlergens { get; set; }
    }
}

