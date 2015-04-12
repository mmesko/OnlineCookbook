using System;


namespace OnlineCookbook.Model.Common
{
   public interface IRecipeAlergen
    {
         int Id { get; set; }
         int AlergenQuantity { get; set; }
         string AlergenUntit { get; set; }
         int RecipeId { get; set; }
         int AlergenId { get; set; }
        //public virtual Alergen Alergen { get; set; }
        //public virtual Recipe Recipe { get; set; }
    }
}
