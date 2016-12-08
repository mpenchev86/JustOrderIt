﻿namespace MvcProject.Web.Areas.Administration.ViewModels.Properties
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PropertyDetailsForDescriptionViewModel : BaseAdminViewModel<int>, IMapFrom<Property>
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Value { get; set; }
    }
}