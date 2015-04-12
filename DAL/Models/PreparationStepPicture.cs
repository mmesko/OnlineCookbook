using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class PreparationStepPicture
    {
        public int Id { get; set; }
        public byte[] StepPicture { get; set; }
        public int PreparationStepId { get; set; }
        public virtual PreparationStep PreparationStep { get; set; }
    }
}
