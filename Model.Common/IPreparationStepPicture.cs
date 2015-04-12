using System;

namespace OnlineCookbook.Model.Common
{
   public interface IPreparationStepPicture
    {
        int Id { get; set; }
        byte[] StepPicture { get; set; }
        int PreparationStepId { get; set; }
        //public virtual PreparationStep PreparationStep { get; set; }

    }
}
