using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model;
using OnlineCookbook.Model.Common;
using WebApplication.Controllers;
using WebApplication.Models;

namespace WebApplication.App_Start
{
    public static class AutoMapperConfig
    {

        public static void Initialize()
        {
            // Model
           OnlineCookbook.Model.Mapping.MappingMaps.Initialize();

            // AlergenContorller
            AutoMapper.Mapper.CreateMap<AlergenModel, AlergenPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<AlergenModel, IAlergen>().ReverseMap();
           

            //IngradientController
           AutoMapper.Mapper.CreateMap<IngradientModel, IngradientPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IngradientModel, IIngradient>().ReverseMap();


            //CategoryController
           AutoMapper.Mapper.CreateMap<CategoryModel, CategoryPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<CategoryModel, ICategory>().ReverseMap();

           //RecipeAlergenController
           AutoMapper.Mapper.CreateMap<RecipeAlergenModel, RecipeAlergenPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeAlergenModel, IRecipeAlergen>().ReverseMap();

           //RecipeAlergenController
           AutoMapper.Mapper.CreateMap<RecipeIngradientModel, RecipeIngradientPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeIngradientModel, IRecipeIngradient>().ReverseMap();

            //FavouriteController
           AutoMapper.Mapper.CreateMap<FavouriteModel, FavouritePOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<FavouriteModel, IFavourite>().ReverseMap();

           
             //UserController
          AutoMapper.Mapper.CreateMap<UserModel, UserPOCO>().ReverseMap();
          AutoMapper.Mapper.CreateMap<UserModel, IUser>().ReverseMap();

 
            // RecipeController
           AutoMapper.Mapper.CreateMap<RecipeModel, RecipePOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeModel, IRecipe>().ReverseMap();

           //CategoryController
           AutoMapper.Mapper.CreateMap<CommentModel, CommentPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<CommentModel, IComment>().ReverseMap();
          
           
        }
    }
}