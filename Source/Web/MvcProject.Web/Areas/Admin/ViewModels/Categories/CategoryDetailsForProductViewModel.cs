﻿namespace MvcProject.Web.Areas.Admin.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    using AutoMapper;
    using MvcProject.Data.Models;
    using MvcProject.GlobalConstants;
    using MvcProject.Web.Infrastructure.Mapping;
    using Products;

    public class CategoryDetailsForProductViewModel : BaseAdminViewModel<int>, IMapFrom<Category>, IHaveCustomMappings
    {
        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(ValidationConstants.CategoryNameMaxLenght)]
        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryDetailsForProductViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}