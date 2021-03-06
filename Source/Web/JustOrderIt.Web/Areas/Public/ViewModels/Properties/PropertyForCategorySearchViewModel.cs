﻿namespace JustOrderIt.Web.Areas.Public.ViewModels.Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Data.Models.Catalog;
    using Infrastructure.Mapping;

    public class PropertyForCategorySearchViewModel : BasePublicViewModel<int>, IMapFrom<Property>, IMapFrom<PropertyCacheViewModel>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}