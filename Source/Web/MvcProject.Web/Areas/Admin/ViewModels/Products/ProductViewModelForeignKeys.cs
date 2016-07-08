﻿namespace MvcProject.Web.Areas.Admin.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Categories;
    using Data.Models;
    using Descriptions;
    using Images;
    using Statistics;

    public class ProductViewModelForeignKeys
    {
        public IEnumerable<DescriptionDetailsForProductViewModel> Descriptions { get; set; }

        public IEnumerable<StatisticsDetailsForProductViewModel> StatisticsCollection { get; set; }

        public IEnumerable<ImageDetailsForProductViewModel> Images { get; set; }

        public IEnumerable<CategoryDetailsForProductViewModel> Categories { get; set; }
    }
}