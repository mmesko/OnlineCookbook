using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class PreparationStepPicturePOCO : IPreparationStepPicture
    {
        public string Id { get; set; }
        public string PreparationStepId { get; set; }
        public byte[] StepPicture { get; set; }
        public virtual IPreparationStep PreparationStep { get; set; }

    }

}
