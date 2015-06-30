using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class PreparationStepPOCO : IPreparationStep
    {
        public PreparationStepPOCO()
        {
            this.PreparationStepPictures = new List<IPreparationStepPicture>();
        }

        public string Id { get; set; }
        public string RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string PreparationText { get; set; }
        public virtual IRecipe Recipe { get; set; }
        public virtual ICollection<IPreparationStepPicture> PreparationStepPictures { get; set; }

    }
}
