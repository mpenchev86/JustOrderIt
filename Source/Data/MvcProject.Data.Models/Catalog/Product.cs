﻿namespace MvcProject.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using MvcProject.GlobalConstants;

    /// <summary>
    /// Represents the entity for a product.
    /// </summary>
    public class Product : BaseEntityModel<int>, IAdministerable
    {
        private ICollection<Tag> tags;
        private ICollection<Image> images;
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Product()
        {
            this.tags = new HashSet<Tag>();
            this.images = new HashSet<Image>();
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        /// <summary>
        /// Gets or sets the title of the product.
        /// </summary>
        /// <value>
        /// The title of the product.
        /// </value>
        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(ValidationConstants.ProductTitleMaxLength)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a short description used in a quick view of a product.
        /// </summary>
        /// <value>
        /// A short description used in a quick view of a product.
        /// </value>
        [DataType(DataType.MultilineText)]
        [MaxLength(ValidationConstants.ProductShortDescriptionMaxLength)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the category of a product.
        /// </summary>
        /// <value>
        /// The foreign key to the category of a product.
        /// </value>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category of a product.
        /// </summary>
        /// <value>
        /// The category of a product.
        /// </value>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to a description of a product.
        /// </summary>
        /// <value>
        /// The foreign key to a description of a product.
        /// </value>
        public int? DescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the description of a product.
        /// </summary>
        /// <value>
        /// The description of a product.
        /// </value>
        public virtual Description Description { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to the statistics entity for a product.
        /// </summary>
        /// <value>
        /// The foreign key to the statistics entity for a product.
        /// </value>
        public int? StatisticsId { get; set; }

        /// <summary>
        /// Gets or sets the statistics entity for a product.
        /// </summary>
        /// <value>
        /// The statistics entity for a product.
        /// </value>
        public virtual Statistics Statistics { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to a main image of a product.
        /// </summary>
        /// <value>
        /// The foreign key to a main image of a product.
        /// </value>
        public int? MainImageId { get; set; }

        /// <summary>
        /// Gets or sets the main image of a product.
        /// </summary>
        /// <value>
        /// The main image of a product.
        /// </value>
        public virtual Image MainImage { get; set; }

        /// <summary>
        /// Gets a value indicating whether the product is in stock (there's one or more items of this product).
        /// </summary>
        /// <value>
        /// A value indicating whether the product is in stock (there's one or more items of this product).
        /// </value>
        public bool IsInStock
        {
            get { return this.QuantityInStock != 0; }
        }

        /// <summary>
        /// Gets or sets the available quantity of a product.
        /// </summary>
        /// <value>
        /// The available quantity of a product.
        /// </value>
        [Required]
        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }

        /// <summary>
        /// Gets or sets the price of a product unit.
        /// </summary>
        /// <value>
        /// The price of a product unit.
        /// </value>
        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the shipping price for one unit of a product.
        /// </summary>
        /// <value>
        /// The shipping price for one unit of a product.
        /// </value>
        [Range(0, double.MaxValue)]
        public decimal? ShippingPrice { get; set; }

        /// <summary>
        /// Gets or sets the length as a physical dimension of a product unit.
        /// </summary>
        /// <value>
        /// The length as a physical dimension of a product unit.
        /// </value>
        [Range(0, double.MaxValue)]
        public double? Length { get; set; }

        /// <summary>
        /// Gets or sets the height as a physical dimension of a product unit.
        /// </summary>
        /// <value>
        /// The height as a physical dimension of a product unit.
        /// </value>
        [Range(0, double.MaxValue)]
        public double? Height { get; set; }

        /// <summary>
        /// Gets or sets the width as a physical dimension of a product unit.
        /// </summary>
        /// <value>
        /// The width as a physical dimension of a product unit.
        /// </value>
        [Range(0, double.MaxValue)]
        public double? Width { get; set; }

        /// <summary>
        /// Gets or sets the weight as a physical dimension of a product unit.
        /// </summary>
        /// <value>
        /// The weight as a physical dimension of a product unit.
        /// </value>
        [Range(0, double.MaxValue)]
        public double? Weight { get; set; }

        /// <summary>
        /// Gets or sets the tags of a product.
        /// </summary>
        /// <value>
        /// The tags of a product.
        /// </value>
        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        /// <summary>
        /// Gets or sets the images of a product.
        /// </summary>
        /// <value>
        /// The images of a product.
        /// </value>
        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        /// <summary>
        /// Gets or sets the comments to a product.
        /// </summary>
        /// <value>
        /// The comments to a product.
        /// </value>
        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        /// <summary>
        /// Gets or sets the votes given to a product.
        /// </summary>
        /// <value>
        /// The votes given to a product.
        /// </value>
        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
