﻿namespace JustOrderIt.Web.Areas.Administration.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using Data.Models;
    using Data.Models.Catalog;
    using JustOrderIt.Common.GlobalConstants;
    using JustOrderIt.Web.Infrastructure.Mapping;

    public class VoteDetailsForProductViewModel : BaseAdminViewModel<int>, IMapFrom<Vote>, IHaveCustomMappings
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [Range(ValidationConstants.VoteValueMin, ValidationConstants.VoteValueMax)]
        public int VoteValue { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Vote, VoteDetailsForProductViewModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}