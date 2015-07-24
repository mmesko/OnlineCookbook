using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipePicture
    {
        public string Id { get; set; }
        public string RecipeId { get; set; }
        public byte[] Picture { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
