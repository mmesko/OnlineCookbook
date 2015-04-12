using System;
using System.Collections.Generic;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public partial class RecipePicturePOCO : IRecipePicture
    {
        public string id { get; set; }
        public byte[] RecipePicture1 { get; set; }
        public int RecipeId { get; set; }
       // public virtual Recipe Recipe { get; set; }
    }
}
