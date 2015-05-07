﻿using System;
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

         public System.Guid Id { get; set; }
         public System.Guid CategoryId { get; set; }
         public System.Guid UserId { get; set; }
         public string RecipeTitle { get; set; }
         public string RecipeDescription { get; set; }
         public bool RecipeComplexity { get; set; }
         public string RecipeText { get; set; }
         public System.Guid Abrv { get; set; }
         public bool HasPicture { get; set; }
         public virtual CategoryPOCO Category { get; set; }
         public virtual ICollection<CommentPOCO> Comments { get; set; }
         public virtual ICollection<FavouritePOCO> Favourites { get; set; }
         public virtual ICollection<PreparationStepPOCO> PreparationSteps { get; set; }
         public virtual UserPOCO User { get; set; }
         public virtual ICollection<RecipeAlergenPOCO> RecipeAlergens { get; set; }
         public virtual ICollection<RecipeIngradientPOCO> RecipeIngradients { get; set; }
         public virtual ICollection<RecipePicturePOCO> RecipePictures { get; set; }

    }
}
