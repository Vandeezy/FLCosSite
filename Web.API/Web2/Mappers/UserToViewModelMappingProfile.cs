using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web2.Models.Users;

namespace Web2.Mappers
{
    public class UserToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "UserToViewModelMappingProfile"; }
        }

        public UserToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<AddUserViewModel, User>();
            CreateMap<EditUserViewModel, User>();
        }
        //protected override void Configure()
        //{

        //}
    }
}