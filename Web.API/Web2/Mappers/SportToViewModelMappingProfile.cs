using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Sports;

namespace Web2.Mappers
{
    public class SportToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "SportToViewModelMappingProfile"; }
        }

        public SportToViewModelMappingProfile()
        {
            CreateMap<Sport, SportViewModel>();
            CreateMap<AddSportViewModel, Sport>();
            CreateMap<EditSportViewModel, Sport>();
        }
    }
}