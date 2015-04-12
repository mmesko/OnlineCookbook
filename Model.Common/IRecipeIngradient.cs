using System;


namespace OnlineCookbook.Model.Common
{
    public interface IRecipeIngradient
    {
         int Id { get; set; }
         int IngradientQuantity { get; set; }
         string IngradientUnit { get; set; }
         int RecipeId { get; set; }
         int IngradientId { get; set; }
       // public virtual Ingradient Ingradient { get; set; }
       // public virtual Recipe Recipe { get; set; }
    }
}
