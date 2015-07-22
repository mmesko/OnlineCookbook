﻿using System;

namespace OnlineCookbook.Model.Common
{
    public interface IRecipePicture
    {
        string Id { get; set; }
        string RecipeId { get; set; }
        byte[] RecipePicture { get; set; }
        IRecipe Recipe { get; set; }
    }
}
