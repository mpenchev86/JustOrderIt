﻿namespace MvcProject.Web.Areas.Administration.ViewModels.Descriptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using MvcProject.Common.GlobalConstants;
    using Properties;

    public class DescriptionDetailsForProductViewModel : BaseAdminViewModel<int>, IMapFrom<Description>, IHaveCustomMappings
    {
        private ICollection<PropertyDetailsForDescriptionViewModel> properties;

        public DescriptionDetailsForProductViewModel()
        {
            this.properties = new HashSet<PropertyDetailsForDescriptionViewModel>();
        }

        [Required]
        [MaxLength(ValidationConstants.DescriptionContentMaxLength)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [UIHint("PropertiesMultiSelectEditor")]
        public ICollection<PropertyDetailsForDescriptionViewModel> Properties
        {
            get { return this.properties; }
            set { this.properties = value; }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Description, DescriptionDetailsForProductViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Properties, opt => opt.MapFrom(
                            src => src.Properties.Select(p => new PropertyDetailsForDescriptionViewModel
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Value = p.Value,
                                CreatedOn = p.CreatedOn,
                                ModifiedOn = p.ModifiedOn
                            })));
        }
    }
}