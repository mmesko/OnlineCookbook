using System;

namespace OnlineCookbook.Model.Common
{
   public interface IPreparationStepPicture
    {
        Guid Id { get; set; }
        Guid PreparationStepId { get; set; }
        byte[] StepPicture { get; set; }
        IPreparationStep PreparationStep { get; set; }
    }
}
