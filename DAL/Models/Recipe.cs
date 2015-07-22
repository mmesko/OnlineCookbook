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
            this.RecipeAlergens = new List<RecipeAlergen>();
            this.RecipeIngradients = new List<RecipeIngradient>();
            this.RecipePictures = new List<RecipePicture>();
           
        }

        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string UserId { get; set; }
        public string RecipeTitle { get; set; }
        public string RecipeDescription { get; set; }
        public bool RecipeComplexity { get; set; }
        public string RecipeText { get; set; }
        public string Abrv { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<RecipeAlergen> RecipeAlergens { get; set; }
        public virtual ICollection<RecipeIngradient> RecipeIngradients { get; set; }
        public virtual ICollection<RecipePicture> RecipePictures { get; set; }
        public virtual User User { get; set; }
    }
}
