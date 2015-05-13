using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class PreparationStepPicturePOCO : IPreparationStepPicture
    {
        public System.Guid Id { get; set; }
        public System.Guid PreparationStepId { get; set; }
        public byte[] StepPicture { get; set; }
        public virtual IPreparationStep PreparationStep { get; set; }

    }

}
