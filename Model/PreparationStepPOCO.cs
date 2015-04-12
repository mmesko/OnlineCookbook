using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class PreparationStepPOCO : IPreparationStep
    {
        public PreparationStepPOCO()
        {
           // this.PreparationStepPictures = new List<PreparationStepPicture>();
        }

        public int Id { get; set; }
        public int StepNumber { get; set; }
        public string PreparationText { get; set; }
        public int RecipeId { get; set; }
        //public virtual Recipe Recipe { get; set; }
        //public virtual ICollection<PreparationStepPicture> PreparationStepPictures { get; set; }

    }
}
