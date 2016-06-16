﻿namespace MvcProject.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using GlobalConstants;
    using Kendo.Mvc.UI;
    using Services.Data;
    using ViewModels.Images;

    [Authorize(Roles = GlobalConstants.IdentityRoles.Admin)]
    public class ImagesController : BaseGridController<Image, ImageViewModel, IImagesService, int>
    {
        private readonly IImagesService imagesService;

        public ImagesController(IImagesService imagesService)
            : base(imagesService)
        {
            this.imagesService = imagesService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public override ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return base.Read(request);
        }

        [HttpPost]
        public override ActionResult Create([DataSourceRequest]DataSourceRequest request, ImageViewModel viewModel)
        {
            if (viewModel != null && this.ModelState.IsValid)
            {
                var entity = new Image { };
                this.PopulateEntity(entity, viewModel);
                this.imagesService.Insert(entity);
                viewModel.Id = entity.Id;
            }

            return base.Create(request, viewModel);
        }

        [HttpPost]
        public override ActionResult Update([DataSourceRequest]DataSourceRequest request, ImageViewModel viewModel)
        {
            if (viewModel != null && this.ModelState.IsValid)
            {
                var entity = new Image { Id = viewModel.Id };
                this.PopulateEntity(entity, viewModel);
                this.imagesService.Update(entity);
            }

            return base.Update(request, viewModel);
        }

        [HttpPost]
        public override ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ImageViewModel viewModel)
        {
            return base.Destroy(request, viewModel);
        }

        protected override void PopulateEntity(Image entity, ImageViewModel viewModel)
        {
            entity.OriginalFileName = viewModel.OriginalFileName;
            entity.ProductId = viewModel.ProductId;
            entity.UrlPath = viewModel.UrlPath;
            entity.FileExtension = viewModel.FileExtension;
            entity.CreatedOn = viewModel.CreatedOn;
            entity.ModifiedOn = viewModel.ModifiedOn;
            entity.IsDeleted = viewModel.IsDeleted;
            entity.DeletedOn = viewModel.DeletedOn;
        }
    }
}