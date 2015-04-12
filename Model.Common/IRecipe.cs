using System;


namespace OnlineCookbook.Model.Common
{
    public interface IRecipe
    {

        int Id { get; set; }
        string RecipeTitle { get; set; }
        string RecipeDescription { get; set; }
        string RecipeComplexity { get; set; }
        string RecipeText { get; set; }
        int UserId { get; set; }
        int CategoryId { get; set; }
       // public virtual Category Category { get; set; } 
        //public virtual User User { get; set; }
        
    }
}
