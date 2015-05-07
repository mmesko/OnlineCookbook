using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class PreparationStepPicture
    {
        public System.Guid Id { get; set; }
        public System.Guid PreparationStepId { get; set; }
        public byte[] StepPicture { get; set; }
        public virtual PreparationStep PreparationStep { get; set; }
    }
}
