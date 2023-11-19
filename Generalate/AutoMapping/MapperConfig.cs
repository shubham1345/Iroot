using AutoMapper;
using Generalate.Controllers;
using Generalate.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.AutoMapping
{
    public static class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TempPersonelDataViewmodel, GetAllPrileView>();
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}