using System;

namespace OnlineCookbook.Model.Common
{
   public interface IPreparationStepPicture
    {
        string Id { get; set; }
        string PreparationStepId { get; set; }
        byte[] StepPicture { get; set; }
        IPreparationStep PreparationStep { get; set; }
    }
}
