﻿using AutoMapper;
using Ninject.Modules;

namespace ToDoApp.Ninject.Modules
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToConstant(CreateConfiguration().CreateMapper()).InSingletonScope();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(assembliesToScan: GetType().Assembly);
            });

            return config;
        }
    }
}
