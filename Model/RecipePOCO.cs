using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;


namespace OnlineCookbook.Model
{
    public partial class RecipePOCO : IRecipe
    {
         public RecipePOCO()
        {
            this.Comments = new List<CommentPOCO>();
            this.Favourites = new List<FavouritePOCO>();
            this.PreparationSteps = new List<PreparationStepPOCO>();
            this.RecipeAlergens = new List<RecipeAlergenPOCO>();
            this.RecipeIngradients = new List<RecipeIngradientPOCO>();
            this.RecipePictures = new List<RecipePicturePOCO>();
        }

        public int Id { get; set; }
        public string RecipeTitle { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeComplexity { get; set; }
        public string RecipeText { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryPOCO Category { get; set; }
        public virtual ICollection<CommentPOCO> Comments { get; set; }
        public virtual ICollection<FavouritePOCO> Favourites { get; set; }
        public virtual ICollection<PreparationStepPOCO> PreparationSteps { get; set; }
        public virtual UserPOCO User { get; set; }
        public virtual ICollection<RecipeAlergenPOCO> RecipeAlergens { get; set; }
        public virtual ICollection<RecipeIngradientPOCO> RecipeIngradients { get; set; }
        public virtual ICollection<RecipePicturePOCO> RecipePictures { get; set; }*/

    }
}
