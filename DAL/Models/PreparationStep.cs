using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class PreparationStep
    {
        public PreparationStep()
        {
            this.PreparationStepPictures = new List<PreparationStepPicture>();
        }

        public string Id { get; set; }
        public string RecipeId { get; set; }
        public int StepNumber { get; set; }
        public string PreparationText { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<PreparationStepPicture> PreparationStepPictures { get; set; }
    }
}
