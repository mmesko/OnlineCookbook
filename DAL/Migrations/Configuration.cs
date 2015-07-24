namespace OnlineCookbook.DAL.Migrations
{
    using OnlineCookbook.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;
    using OnlineCookbook.Utilities;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineCookbook.DAL.Models.CookBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineCookbook.DAL.Models.CookBookContext context)
        {


            //Chocolate cake
            //Image image1 = Image.FromFile(@"C:\Users\mmesko00\Desktop\images\slika1.png");
            //Recipe recipe = context.Recipes.Where(g => g.RecipeTitle == "Chocolate cake").First();
            //recipe.RecipePictures = new List<RecipePicture>()
            //{
            //    new RecipePicture()
            //    {   Id = "95c9a694-f5e5-4dab-b4ae-c8b8e131d18b",
            //        RecipeId = recipe.Id,
            //        Picture = Utilities.ImageToArray(image1)
            //    }

            //};
            //context.Recipes.AddOrUpdate(recipe);

            Image image2 = Image.FromFile(@"C:\Users\mmesko00\Desktop\images\slika2.png");
            Recipe recipe2 = context.Recipes.Where(g => g.RecipeTitle == "Greek salad").First();
            recipe2.RecipePictures = new List<RecipePicture>()
            {
                new RecipePicture()
                {   Id = "c829adb4-f6db-4bd6-9ba7-f052a305b2e8",
                    RecipeId = recipe2.Id,
                    Picture = Utilities.ImageToArray(image2)
                }

            };
            context.Recipes.AddOrUpdate(recipe2);

            context.SaveChanges();

        

            
        }
    }
}
