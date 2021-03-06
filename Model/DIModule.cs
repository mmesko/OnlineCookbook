﻿using OnlineCookbook.Model.Common;

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
            Bind<IRecipeAlergen>().To<RecipeAlergenPOCO>();
            Bind<IUser>().To<UserPOCO>();
            Bind<IRecipeIngradient>().To<RecipeIngradientPOCO>();           
            


            // Za users
            //Bind(typeof(IUserStore<User>)).To(typeof(UserStore<User>));
            //Bind(typeof(UserManager<User>)).ToSelf();
            //Bind(typeof(IdentityDbContext)).To(typeof(CookBookContext));
        }
    }
}
