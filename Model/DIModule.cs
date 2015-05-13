using System;
using OnlineCookbook.Model.Common;

namespace OnlineCookbook.Model
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IAlergen>().To<AlergenPOCO>();
            Bind<ICategory>().To<CategoryPOCO>();
            Bind<IComment>().To<CommentPOCO>();
            Bind<IFavourite>().To<FavouritePOCO>();
            Bind<IFavouriteUser>().To<FavouriteUserPOCO>();
            Bind<IIngradient>().To<IngradientPOCO>();
            Bind<IMessage>().To<MessagePOCO>();
            Bind<IMessageUser>().To<MessageUserPOCO>();
            Bind<IRecipe>().To<RecipePOCO>();
            Bind<IRole>().To<RolePOCO>();
            Bind<IRecipeAlergen>().To<RecipeAlergenPOCO>();
            Bind<IUser>().To<UserPOCO>();
            Bind<IRecipeIngradient>().To<RecipeIngradientPOCO>();
            Bind<IUserRole>().To<UserRolePOCO>();
            Bind<IPreparationStep>().To<PreparationStepPOCO>();
            Bind<IPreparationStepPicture>().To<PreparationStepPicturePOCO>();
            Bind<IRecipePicture>().To<RecipePicturePOCO>();
        }
    }
}
