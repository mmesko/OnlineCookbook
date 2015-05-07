using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            this.Comments = new List<Comment>();
            this.Favourites = new List<Favourite>();
            this.PreparationSteps = new List<PreparationStep>();
            this.RecipeAlergens = new List<RecipeAlergen>();
            this.RecipeIngradients = new List<RecipeIngradient>();
            this.RecipePictures = new List<RecipePicture>();
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
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<PreparationStep> PreparationSteps { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<RecipeAlergen> RecipeAlergens { get; set; }
        public virtual ICollection<RecipeIngradient> RecipeIngradients { get; set; }
        public virtual ICollection<RecipePicture> RecipePictures { get; set; }
    }
}
