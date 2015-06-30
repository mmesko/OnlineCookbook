using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipePicturePOCO : IRecipePicture
    {
        public string Id { get; set; }
        public string RecipeId { get; set; }
        public byte[] RecipePicture1 { get; set; }
        public virtual IRecipe Recipe { get; set; }
    }
}
