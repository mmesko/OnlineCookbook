using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class PreparationStepPOCO : IPreparationStep
    {
        public PreparationStepPOCO()
        {
            this.PreparationStepPictures = new List<PreparationStepPicturePOCO>();
        }

        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string PreparationText { get; set; }
        public int RecipeId { get; set; }
        public virtual RecipePOCO Recipe { get; set; }
        public virtual ICollection<PreparationStepPicturePOCO> PreparationStepPictures { get; set; }

    }
}
