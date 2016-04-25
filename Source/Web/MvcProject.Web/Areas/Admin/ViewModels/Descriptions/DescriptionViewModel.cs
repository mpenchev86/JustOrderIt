﻿namespace MvcProject.Web.Areas.Admin.ViewModels.Descriptions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Properties;

    public class DescriptionViewModel : BaseAdminViewModel, IMapFrom<Description>, IHaveCustomMappings
    {
        private ICollection<PropertyDetailsViewModel> properties;

        public DescriptionViewModel()
        {
            this.properties = new HashSet<PropertyDetailsViewModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        //[MaxLength(ValidationConstants.MaxFullDescriptionLength)]
        public string Content { get; set; }

        //public int? ProductId { get; set; }

        public virtual ICollection<PropertyDetailsViewModel> Properties
        {
            get { return this.properties; }
            set { this.properties = value; }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Description, DescriptionViewModel>()
                //.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Properties, opt => opt.MapFrom(
                           src => src.Properties.Select(p => new PropertyDetailsViewModel
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Value = p.Value
                           })))
                ;
        }
    }
}