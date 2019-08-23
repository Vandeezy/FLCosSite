using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Sports;

namespace Web.App_Start
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sport, SportViewModel>();
                cfg.CreateMap<AddSportViewModel, Sport>();
                cfg.CreateMap<EditSportViewModel, Sport>();
            });
            var mapper = configuration.CreateMapper();
        }
    }
}