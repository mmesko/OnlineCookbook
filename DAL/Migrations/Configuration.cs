namespace OnlineCookbook.DAL.Migrations
{
    using OnlineCookbook.Utilities;
    using OnlineCookbook.DAL.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineCookbook.DAL.Models.CookBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineCookbook.DAL.Models.CookBookContext context)
        {

            try
            {
                //Èokoladna torta
                Image image1 = Image.FromFile(@"C:\Users\mmesko00\Desktop\images\slika1.png");
                Recipe recipe = context.Recipes.Where(g => g.RecipeTitle == "Èokoladna torta").First();
                recipe.RecipePictures = new List<RecipePicture>()
            {
                new RecipePicture()
                {
                    RecipeId = recipe.Id,
                    RecipePicture1 = Utilities.ImageToArray(image1)
                }
               
            };
                context.Recipes.AddOrUpdate(recipe);

            }
            catch (System.Exception e)
            {
                
                throw e;
            }
           
        }
    }
}
