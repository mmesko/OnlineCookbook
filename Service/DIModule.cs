using System;
using OnlineCookbook.Service.Common;

namespace OnlineCookbook.Service
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IAlergenService>().To<AlergenService>();
            Bind<IIngradientService>().To<IngradientService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IIngradientService>().To<IngradientService>();
            
        }
    }
}
