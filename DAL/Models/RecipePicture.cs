using System;
using System.Collections.Generic;

namespace OnlineCookbook.DAL.Models
{
    public partial class RecipePicture
    {
        public System.Guid Id { get; set; }
        public System.Guid RecipeId { get; set; }
        public byte[] RecipePicture1 { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
