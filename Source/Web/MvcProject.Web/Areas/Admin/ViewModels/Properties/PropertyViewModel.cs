﻿namespace MvcProject.Web.Areas.Admin.ViewModels.Properties
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PropertyViewModel : IMapFrom<Property>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }

        public int DescriptionId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Property, PropertyViewModel>()
                .ForMember(dest => dest.DescriptionId, opt => opt.MapFrom(src => src.DescriptionId));
        }
    }
}