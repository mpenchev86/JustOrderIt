﻿namespace MvcProject.Web.Areas.Admin.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserPostModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public void CreateMappings(IMapperConfiguration configuration)
        {
            //configuration.CreateMap<ApplicationUser, PostUserViewModel>().ForAllMembers();
        }
    }
}