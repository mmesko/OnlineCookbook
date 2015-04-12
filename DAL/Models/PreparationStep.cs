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

        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string PreparationText { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual ICollection<PreparationStepPicture> PreparationStepPictures { get; set; }
    }
}
