using System;


namespace OnlineCookbook.Model.Common
{
    public interface IPreparationStep
    {

        int Id { get; set; }
        int StepNumber { get; set; }
        string PreparationText { get; set; }
        int RecipeId { get; set; }
        //public virtual Recipe Recipe { get; set; }

    }
}
