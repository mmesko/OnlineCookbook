﻿using System;
using OnlineCookbook.Model.Common;
using OnlineCookbook.Model;
using OnlineCookbook.Repository.Common;
using OnlineCookbook.DAL.Models;
using Ninject.Extensions.Factory;


namespace OnlineCookbook.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {

            Bind<IAlergenRepository>().To<AlergenRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IRecipeRepository>().To<RecipeRepository>();
            



            Bind<ICookBookContext>().To<CookBookContext>();
            Bind<IRepository>().To<Repository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory();

        }

    }
}