using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IPreparationStep
    {
        string Id { get; set; }
        string RecipeId { get; set; }
        int StepNumber { get; set; }
        string PreparationText { get; set; }
        IRecipe Recipe { get; set; }
        ICollection<IPreparationStepPicture> PreparationStepPictures { get; set; }

        
    }
}
