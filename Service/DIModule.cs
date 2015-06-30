using System;
using OnlineCookbook.Service.Common;

namespace OnlineCookbook.Service
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IAlergenService>().To<AlergenService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IIngradientService>().To<IngradientService>();           
            Bind<IUserService>().To<UserService>();
            Bind<IRecipeAlergenService>().To<RecipeAlergenService>();
            Bind<IRecipeIngradientService>().To<RecipeIngradientService>();
            Bind<IRecipePictureService>().To<RecipePictureService>();
            Bind<IFavouriteService>().To<FavouriteService>();
            Bind<IRecipeService>().To<RecipeService>();
            Bind<IPreparationStepPictureService>().To<PreparationStepPictureService>();
            Bind<ICommentService>().To<CommentService>();
            
        }
    }
}
