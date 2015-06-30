using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class PreparationStepPicture
    {
        public string Id { get; set; }
        public string PreparationStepId { get; set; }
        public byte[] StepPicture { get; set; }
        public virtual PreparationStep PreparationStep { get; set; }
    }
}
