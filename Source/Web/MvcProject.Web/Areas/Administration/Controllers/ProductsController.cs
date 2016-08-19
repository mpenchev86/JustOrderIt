﻿namespace MvcProject.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Models;
    using Data.Models.Contracts;
    using MvcProject.Common.GlobalConstants;
    using Infrastructure.Extensions;
    using Infrastructure.Filters.ActionMethodSelectors;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.Categories;
    using ViewModels.Comments;
    using ViewModels.Descriptions;
    using ViewModels.Images;
    using ViewModels.Products;
    using ViewModels.Properties;
    using ViewModels.Tags;
    using ViewModels.Votes;
    using ViewModels.Users;
    using Services.Data.ServiceModels;
    using System.Web;
    using System.IO;
    using System.Web.SessionState;
    using Services.Logic;
    using Services.Logic.ServiceModels;

    [Authorize(Roles = IdentityRoles.Admin)]
    public class ProductsController : BaseGridController<Product, ProductViewModel, IProductsService, int>
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;
        private readonly ICommentsService commentsService;
        private readonly IImagesService imagesService;
        private readonly IFileSystemService fileSystemService;
        private readonly IDescriptionsService descriptionsService;
        private readonly ITagsService tagsService;
        private readonly IUsersService usersService;
        private readonly IVotesService votesService;

        public ProductsController(
            IProductsService productsService,
            ICategoriesService categoriesService,
            ICommentsService commentsService,
            IImagesService imagesService,
            IDescriptionsService descriptionsService,
            ITagsService tagsService,
            IUsersService usersService,
            IVotesService votesService,
            IFileSystemService fileSystemService)
            : base(productsService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
            this.commentsService = commentsService;
            this.imagesService = imagesService;
            this.descriptionsService = descriptionsService;
            this.tagsService = tagsService;
            this.votesService = votesService;
            this.usersService = usersService;
            this.fileSystemService = fileSystemService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var foreignKeys = new ProductViewModelForeignKeys
            {
                Categories = this.categoriesService.GetAll().To<CategoryDetailsForProductViewModel>(),
                Images = this.imagesService.GetAll().To<ImageDetailsForProductViewModel>(),
                Descriptions = this.descriptionsService.GetAll().To<DescriptionDetailsForProductViewModel>(),
                Sellers = this.usersService.GetAll().Where(u => u.Roles.Any(r => r.RoleName == IdentityRoles.Seller)).To<UserDetailsForProductViewModel>(),
            };

            return this.View(foreignKeys);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return base.Read(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([DataSourceRequest]DataSourceRequest request, ProductViewModel viewModel, IEnumerable<string> fileNames, IEnumerable<int> productImagesIds)
        {
            if (viewModel != null && this.ModelState.IsValid)
            {
                var entity = new Product();
                this.PopulateEntity(entity, viewModel);

                //var rawFiles = viewModel.Images.AsQueryable().To<RawFile>().ToList();
                //var processedImages = this.imagesService.ProcessImages(rawFiles/*viewModel.Images .Select(ImageDetailsForProductViewModel.ToRawFile) .AsQueryable().To<RawFile>()*/);
                //this.imagesService.SaveImages(processedImages);

                //entity.Images = processedImages.AsQueryable().To<Image>().ToList();

                entity.Images = this.imagesService.GetAll().Where(img => productImagesIds.Contains(img.Id)).ToList();

                this.productsService.Insert(entity);
                viewModel.Id = entity.Id;

                //var productImages = this.imagesService.GetAll().Where(img => productImagesIds.Contains(img.Id));
                //foreach (var image in productImages)
                //{
                //    image.ProductId = viewModel.Id;
                //}

                //this.imagesService.UpdateMany(productImages);
            }

            return this.GetEntityAsDataSourceResult(request, viewModel, this.ModelState);

            //return base.Create(request, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Update([DataSourceRequest]DataSourceRequest request, ProductViewModel viewModel)
        {
            return base.Update(request, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ProductViewModel viewModel)
        {
            HandleDependingEntities(viewModel);
            return base.Destroy(request, viewModel);
        }

        #region DataProviders
        public ActionResult SaveImages(IEnumerable<HttpPostedFileBase> productImages)
        {
            var fileNames = new List<string>();
            var productImagesIds = new List<int>();
            var rawFiles = new List<RawFile>();

            //The Name of the Upload component is "productImages".
            foreach (var file in productImages)
            {
                ////Some browsers send file names with a full path. You only care about the file name.
                //var fileName = Path.GetFileName(file.FileName);
                //var destinationPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                //file.SaveAs(destinationPath);

                var rawFile = this.fileSystemService.ToRawFile(file);
                if (rawFile == null)
                {
                    // skip invalid files
                    continue;
                }

                rawFiles.Add(rawFile);
                fileNames.Add(file.FileName);
            }

            var processedImages = this.imagesService.ProcessImages(rawFiles);
            this.imagesService.SaveImages(processedImages);
            productImagesIds = new List<int>(processedImages.Select(i => i.Id));

            return Json(new { fileNames = fileNames, productImagesIds = productImagesIds }, "text/plain");
        }

        [HttpGet]
        public JsonResult GetAllTags()
        {
            var tags = this.tagsService.GetAll().To<TagDetailsForProductViewModel>();
            return this.Json(tags, JsonRequestBehavior.AllowGet);
        }

        protected override void PopulateEntity(Product entity, ProductViewModel viewModel)
        {
            if (viewModel.Comments != null)
            {
                foreach (var comment in viewModel.Comments)
                {
                    entity.Comments.Add(this.commentsService.GetById(comment.Id));
                }
            }

            if (viewModel.Images != null)
            {
                foreach (var image in viewModel.Images)
                {
                    entity.Images.Add(this.imagesService.GetById(image.Id));
                }
            }

            if (viewModel.Votes != null)
            {
                foreach (var vote in viewModel.Votes)
                {
                    entity.Votes.Add(this.votesService.GetById(vote.Id));
                }
            }

            var tagIds = viewModel.Tags.Select(tag => tag.Id);
            this.ProcessProductTags(entity, viewModel.Id, tagIds);

            entity.Title = viewModel.Title;
            entity.ShortDescription = viewModel.ShortDescription;
            entity.CategoryId = viewModel.CategoryId;
            entity.DescriptionId = viewModel.DescriptionId;
            entity.SellerId = viewModel.SellerId;
            entity.MainImageId = viewModel.MainImageId;
            entity.QuantityInStock = viewModel.QuantityInStock;
            entity.UnitPrice = viewModel.UnitPrice;
            entity.ShippingPrice = viewModel.ShippingPrice;
            entity.AllTimeItemsSold = viewModel.AllTimeItemsSold;
            entity.CreatedOn = viewModel.CreatedOn;
            entity.ModifiedOn = viewModel.ModifiedOn;
            entity.IsDeleted = viewModel.IsDeleted;
            entity.DeletedOn = viewModel.DeletedOn;
        }

        private void ProcessProductTags(Product entity, int productId, IEnumerable<int> tagIds)
        {
            entity.Tags.Clear();
            foreach (var tagId in tagIds)
            {
                var tag = this.tagsService.GetById(tagId);
                entity.Tags.Add(tag);
            }
        }

        private void HandleDependingEntities(ProductViewModel viewModel)
        {

        }
        #endregion
    }
}