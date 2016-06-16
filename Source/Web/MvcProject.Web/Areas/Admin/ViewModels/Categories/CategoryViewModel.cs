﻿namespace MvcProject.Web.Areas.Admin.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Infrastructure.DataAnnotations;
    using MvcProject.Data.Models;
    using MvcProject.Web.Infrastructure.Mapping;
    using Products;

    public class CategoryViewModel : BaseAdminViewModel<int>, IMapFrom<Category>, IHaveCustomMappings
    {
        private ICollection<ProductDetailsForCategoryViewModel> products;

        public CategoryViewModel()
        {
            this.products = new HashSet<ProductDetailsForCategoryViewModel>();
        }

        //[Key]
        //public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<ProductDetailsForCategoryViewModel> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        [Index]
        public bool IsDeleted { get; set; }

        [LongDateTimeFormat]
        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(
                           src => src.Products.Select(p => new ProductDetailsForCategoryViewModel
                           {
                               Id = p.Id,
                               Title = p.Title,
                               ShortDescription = p.ShortDescription,
                               UnitPrice = p.UnitPrice
                           })))
                ;
        }
    }
}