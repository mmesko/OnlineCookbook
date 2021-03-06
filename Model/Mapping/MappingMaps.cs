﻿using OnlineCookbook.Model.Common;
using OnlineCookbook.DAL.Models;

namespace OnlineCookbook.Model.Mapping
{
   public static class MappingMaps
    {
       public static void Initialize()
       {
           AutoMapper.Mapper.CreateMap<AlergenPOCO, Alergen>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IAlergen, Alergen>().ReverseMap();

           AutoMapper.Mapper.CreateMap<CategoryPOCO, Category>().ReverseMap();
           AutoMapper.Mapper.CreateMap<ICategory, Category>().ReverseMap();

           AutoMapper.Mapper.CreateMap<CommentPOCO, Comment>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IComment, Comment>().ReverseMap();

           AutoMapper.Mapper.CreateMap<FavouritePOCO, Favourite>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IFavourite, Favourite>().ReverseMap();

           AutoMapper.Mapper.CreateMap<FavouriteUserPOCO, FavouriteUser>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IFavouriteUser, FavouriteUser>().ReverseMap();

           AutoMapper.Mapper.CreateMap<IngradientPOCO, Ingradient>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IIngradient, Ingradient>().ReverseMap();

           AutoMapper.Mapper.CreateMap<MessagePOCO, Message>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IMessage, Message>().ReverseMap();

           AutoMapper.Mapper.CreateMap<MessageUserPOCO, MessageUser>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IMessageUser, MessageUser>().ReverseMap();

           AutoMapper.Mapper.CreateMap<RecipePicturePOCO, RecipePicture>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IRecipePicture, RecipePicture>().ReverseMap();
          

           AutoMapper.Mapper.CreateMap<RecipePOCO, Recipe>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IRecipe, Recipe>().ReverseMap();

           AutoMapper.Mapper.CreateMap<UserPOCO, User>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IUser, User>().ReverseMap();
          

           AutoMapper.Mapper.CreateMap<RecipeAlergenPOCO, RecipeAlergen>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IRecipeAlergen, RecipeAlergen>().ReverseMap();

           AutoMapper.Mapper.CreateMap<RecipeIngradientPOCO, RecipeIngradient>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IRecipeIngradient, RecipeIngradient>().ReverseMap();

          

       }

    }
}
