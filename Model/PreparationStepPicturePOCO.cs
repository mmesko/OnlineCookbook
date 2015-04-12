using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class PreparationStepPicturePOCO : IPreparationStepPicture
    {
        public int Id { get; set; }
        public byte[] StepPicture { get; set; }
        public int PreparationStepId { get; set; }
        //public virtual PreparationStep PreparationStep { get; set; }

    }

}
