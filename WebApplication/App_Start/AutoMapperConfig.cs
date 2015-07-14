using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCookbook.DAL.Models;
using OnlineCookbook.Model;
using OnlineCookbook.Model.Common;
using WebApplication.Controllers;

namespace WebApplication.App_Start
{
    public static class AutoMapperConfig
    {

        public static void Initialize()
        {
            // Model
           OnlineCookbook.Model.Mapping.MappingMaps.Initialize();

            // AlergenContorller
            AutoMapper.Mapper.CreateMap<AlergenController.AlergenModel, AlergenPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<AlergenController.AlergenModel, IAlergen>().ReverseMap();
           

            //IngradientController
           AutoMapper.Mapper.CreateMap<IngradientController.IngradientModel, IngradientPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<IngradientController.IngradientModel, IIngradient>().ReverseMap();


            //CategoryController
           AutoMapper.Mapper.CreateMap<CategoryController.CategoryModel, CategoryPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<CategoryController.CategoryModel, ICategory>().ReverseMap();

           //RecipeAlergenController
           AutoMapper.Mapper.CreateMap<RecipeAlergenController.RecipeAlergenModel, RecipeAlergenPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeAlergenController.RecipeAlergenModel, IRecipeAlergen>().ReverseMap();

           //RecipeAlergenController
           AutoMapper.Mapper.CreateMap<RecipeIngradientController.RecipeIngradientModel, RecipeIngradientPOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeIngradientController.RecipeIngradientModel, IRecipeIngradient>().ReverseMap();

            //FavouriteController
           AutoMapper.Mapper.CreateMap<FavouriteController.FavouriteModel, FavouritePOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<FavouriteController.FavouriteModel, IFavourite>().ReverseMap();

           
             //UserController
          AutoMapper.Mapper.CreateMap<WebApplication.Models.UserModel, UserPOCO>().ReverseMap();
          AutoMapper.Mapper.CreateMap<WebApplication.Models.UserModel, IUser>().ReverseMap();

 
            // RecipeController
           AutoMapper.Mapper.CreateMap<RecipeController.RecipeModel, RecipePOCO>().ReverseMap();
           AutoMapper.Mapper.CreateMap<RecipeController.RecipeModel, IRecipe>().ReverseMap();
           

          
           
        }
    }
}