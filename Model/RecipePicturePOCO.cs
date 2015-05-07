using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipePicturePOCO : IRecipePicture
    {
        public System.Guid Id { get; set; }
        public System.Guid RecipeId { get; set; }
        public byte[] RecipePicture1 { get; set; }
        public virtual RecipePOCO Recipe { get; set; }
    }
}
