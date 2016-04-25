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

    public class PropertyDetailsViewModel : IMapFrom<Property>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            //throw new NotImplementedException();
        }
    }
}