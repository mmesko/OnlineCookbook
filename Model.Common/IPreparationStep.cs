using System;
using System.Collections.Generic;

namespace OnlineCookbook.Model.Common
{
    public interface IPreparationStep
    {
        Guid Id { get; set; }
        Guid RecipeId { get; set; }
        int StepNumber { get; set; }
        string PreparationText { get; set; }
        bool HasPicture { get; set; }
        IRecipe Recipe { get; set; }
        ICollection<IPreparationStepPicture> PreparationStepPictures { get; set; }

        
    }
}
