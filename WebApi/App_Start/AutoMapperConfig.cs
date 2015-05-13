using OnlineCookbook.Model;
using OnlineCookbook.Model.Common;
using OnlineCookbook.WebApi.Controllers;

namespace OnlineCookbook.WebApi.App_Start
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
           

            // IngradientController
            AutoMapper.Mapper.CreateMap<IngradientController.IngradientModel, IngradientPOCO>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IngradientController.IngradientModel, IIngradient>().ReverseMap();
           

           
            
            // RoleController
          //  AutoMapper.Mapper.CreateMap<RoleController.RoleModel, Role>().ReverseMap();
          //  AutoMapper.Mapper.CreateMap<RoleController.RoleModel, IRole>().ReverseMap();

 
            // UserController



        }
    }
}