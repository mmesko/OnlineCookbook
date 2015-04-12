using System;


namespace OnlineCookbook.Model.Common
{
    public interface IRecipePicture
    {
        string id { get; set; }
        byte[] RecipePicture1 { get; set; }
        int RecipeId { get; set; }
        //public virtual Recipe Recipe { get; set; }
    }
}
