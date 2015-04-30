using System;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model;
using OnlineCookbook.Model.Common;


namespace OnlineCookbook.Repository.Mapping
{
   public static class MappingMaps
    {

       public static void Init()
       {

           AutoMapper.Mapper.CreateMap<AlergenPOCO, Alergen>().ReverseMap();
           AutoMapper.Mapper.CreateMap<CategoryPOCO, Category>().ReverseMap();
           AutoMapper.Mapper.CreateMap<CommentPOCO, Comment>().ReverseMap();
           AutoMapper.Mapper.CreateMap<FavouritePOCO, Favourite>().ReverseMap();
           AutoMapper.Mapper.CreateMap<FavouriteUserPOCO, FavouriteUser>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IngradientPOCO, Ingradient>().ReverseMap();
           AutoMapper.Mapper.CreateMap<MessagePOCO, Message>().ReverseMap();
           AutoMapper.Mapper.CreateMap<MessageUserPOCO, MessageUser>().ReverseMap();
           AutoMapper.Mapper.CreateMap<PreparationStepPicturePOCO, PreparationStepPicture>().ReverseMap();
           AutoMapper.Mapper.CreateMap<PreparationStepPOCO, PreparationStep>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeAlergenPOCO, RecipeAlergen>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeIngradientPOCO, RecipeIngradient>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipePicturePOCO, RecipePicture>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipePOCO, Recipe>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RolePOCO, Role>().ReverseMap();
           AutoMapper.Mapper.CreateMap<UserPOCO, User>().ReverseMap();
           AutoMapper.Mapper.CreateMap<UserRolePOCO, UserRole>().ReverseMap();



           
       
       
       }



    }
}
