﻿namespace MvcProject.Web.Areas.Admin.ViewModels.Images
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Elmah.ContentSyndication;
    using MvcProject.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ValidationConstants.MaxOriginalFileNameLength)]
        public string OriginalFileName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.ValidationConstants.MaxFileExtensionLength)]
        public string FileExtension { get; set; }

        public string UrlPath { get; set; }

        public int? ProductId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            //throw new NotImplementedException();
        }
    }
}