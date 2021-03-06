﻿namespace JustOrderIt.Web.Public.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Areas.Public.Controllers;
    using Areas.Public.ViewModels.Comments;
    using Areas.Public.ViewModels.Products;
    using Data.Models.Catalog;
    using Data.Models.Identity;
    using Infrastructure.Mapping;
    using Moq;
    using NUnit.Framework;
    using Services.Data;
    using Services.Web;
    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class ProductsControllerTests
    {
        private AutoMapperConfig autoMapperConfig;
        private Mock<IProductsService> productsServiceMock;
        private Mock<IVotesService> votesServiceMock;
        private Mock<IIdentifierProvider> identifierProviderMock;
        private Mock<IMappingService> mappingServiceMock;

        public ProductsControllerTests()
        {
            this.PrepareController();
        }

        [Test]
        public void IndexShouldWorkCorrectly()
        {
            // Arrange
            var productId = 43;
            var product = new Product();
            this.identifierProviderMock.Setup(x => x.DecodeToIntId(It.IsAny<string>())).Returns(productId);
            this.productsServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(product);
            var viewModel = new ProductFullViewModel();
            this.mappingServiceMock.Setup(x => x.Map<Product, ProductFullViewModel>(It.IsAny<Product>())).Returns(viewModel);

            // Act
            var controller = new ProductsController(this.productsServiceMock.Object, this.identifierProviderMock.Object, this.votesServiceMock.Object, this.mappingServiceMock.Object);

            // Assert
            controller.WithCallTo(x => x.Index("jkfgksdf"))
                .ShouldRenderDefaultView()
                .WithModel<ProductFullViewModel>(
                vm =>
                {
                    Assert.IsNotNull(vm);
                    Assert.AreEqual(vm, viewModel);
                });
        }

        [Test]
        public void SneakPeekShouldReturnMessageContentIfRequestIsNotAjax()
        {
            // Arrange
            var requestMock = new Mock<HttpRequestBase>();
            requestMock.Setup(x => x.Headers).Returns(new NameValueCollection());
            requestMock.SetupGet(x => x.AppRelativeCurrentExecutionFilePath).Returns(It.IsAny<string>());
            var responseMock = new Mock<HttpResponseBase>();
            responseMock.SetupGet(x => x.StatusCode).Returns(/*(int)HttpStatusCode.Forbidden*/It.IsAny<int>());
            responseMock.SetupSet(x => x.StatusCode = It.IsAny<int>());
            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(x => x.HttpContext.Request).Returns(requestMock.Object);
            controllerContextMock.SetupGet(x => x.HttpContext.Response).Returns(responseMock.Object);

            // Act
            var controller = new ProductsController(this.productsServiceMock.Object, this.identifierProviderMock.Object, this.votesServiceMock.Object, this.mappingServiceMock.Object);
            controller.ControllerContext = controllerContextMock.Object;

            // Assert
            //controller.WithCallTo(x => x.SneakPeek(It.IsAny<string>()))
            //    .ShouldGiveHttpStatus(HttpStatusCode.Forbidden);

            controller.WithCallTo(x => x.SneakPeek(It.IsAny<string>()))
                .ShouldReturnContent(It.IsAny<string>());
        }

        [Test]
        public void SneakPeekShouldReturnMessageContentIfProductIsNull()
        {
            // Arrange
            var product = this.GetProduct();
            this.identifierProviderMock.Setup(x => x.DecodeToIntId(It.IsAny<string>())).Returns(product.Id);
            this.productsServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns<Product>(null);
            var requestMock = new Mock<HttpRequestBase>();
            requestMock.Setup(x => x.Headers).Returns(new NameValueCollection());
            requestMock.SetupGet(x => x.AppRelativeCurrentExecutionFilePath).Returns(It.IsAny<string>());
            requestMock.Object.Headers.Add("X-Requested-With", "XMLHttpRequest");
            var responseMock = new Mock<HttpResponseBase>();
            responseMock.SetupGet(x => x.StatusCode).Returns(/*(int)HttpStatusCode.Forbidden*/It.IsAny<int>());
            responseMock.SetupSet(x => x.StatusCode = It.IsAny<int>());
            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(x => x.HttpContext.Request).Returns(requestMock.Object);
            controllerContextMock.SetupGet(x => x.HttpContext.Response).Returns(responseMock.Object);

            // Act
            var controller = new ProductsController(this.productsServiceMock.Object, this.identifierProviderMock.Object, this.votesServiceMock.Object, this.mappingServiceMock.Object);
            controller.ControllerContext = controllerContextMock.Object;

            // Assert
            controller.WithCallTo(x => x.SneakPeek(It.IsAny<string>()))
                .ShouldReturnContent(It.IsAny<string>());
        }

        [Test]
        public void SneakPeekShouldReturnPartialViewResultIfProductExists()
        {
            // Arrange
            var product = this.GetProduct();
            this.identifierProviderMock.Setup(x => x.DecodeToIntId(It.IsAny<string>())).Returns(product.Id);
            this.productsServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(product);
            var viewModel = new ProductSneakPeekViewModel();
            this.mappingServiceMock.Setup(x => x.Map<Product, ProductSneakPeekViewModel>(It.IsAny<Product>())).Returns(viewModel);
            var requestMock = new Mock<HttpRequestBase>();
            requestMock.Setup(x => x.Headers).Returns(new NameValueCollection());
            requestMock.SetupGet(x => x.AppRelativeCurrentExecutionFilePath).Returns(It.IsAny<string>());
            requestMock.Object.Headers.Add("X-Requested-With", "XMLHttpRequest");
            var responseMock = new Mock<HttpResponseBase>();
            responseMock.SetupGet(x => x.StatusCode).Returns(/*(int)HttpStatusCode.Forbidden*/It.IsAny<int>());
            responseMock.SetupSet(x => x.StatusCode = It.IsAny<int>());
            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.SetupGet(x => x.HttpContext.Request).Returns(requestMock.Object);
            controllerContextMock.SetupGet(x => x.HttpContext.Response).Returns(responseMock.Object);

            // Act
            var controller = new ProductsController(this.productsServiceMock.Object, this.identifierProviderMock.Object, this.votesServiceMock.Object, this.mappingServiceMock.Object);
            controller.ControllerContext = controllerContextMock.Object;

            // Assert
            controller.WithCallTo(x => x.SneakPeek(It.IsAny<string>()))
                .ShouldRenderDefaultPartialView()
                .WithModel<ProductSneakPeekViewModel>(vm => 
                {
                    Assert.IsNotNull(vm);
                    Assert.AreEqual(vm, viewModel);
                });
        }

        #region Helpers
        private void PrepareController()
        {
            this.autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(ProductsController).Assembly);
            this.productsServiceMock = new Mock<IProductsService>();
            this.votesServiceMock = new Mock<IVotesService>();
            this.identifierProviderMock = new Mock<IIdentifierProvider>();
            this.mappingServiceMock = new Mock<IMappingService>();
        }

        private ProductFullViewModel GetProductViewModel()
        {
            return new ProductFullViewModel()
            {
                CommentsWithRatings = new List<CommentWithRatingViewModel>()
                {
                    new CommentWithRatingViewModel() { Id = 1, CommentCreatedOn = DateTime.Now, CommentContent = "jkkuiqhjvcjhbmqkwhkjkukgausu", UserName = "bcvqiboqq", Rating = 2 },
                    new CommentWithRatingViewModel() { Id = 3, CommentCreatedOn = DateTime.Now, CommentContent = "jkkuiqhjvcjhbmqkwhkjkukgausu", UserName = "bcvqiboqq", Rating = 4},
                    new CommentWithRatingViewModel() { Id = 2, CommentCreatedOn = DateTime.Now, CommentContent = "jkkuiqhjvcjhbmqkwhkjkukgausu", UserName = "bcvqiboqq", },
                    new CommentWithRatingViewModel() { Id = 5, CommentCreatedOn = DateTime.Now, CommentContent = "jkkuiqhjvcjhbmqkwhkjkukgausu", UserName = "bcvqiboqq", },
                },
            };
        }

        private Product GetProduct()
        {
            return new Product()
            {
                Id = 43,
                
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = 2,
                        CreatedOn = DateTime.Now,
                        Content = "ioqtrwytejhdgavshdklioqwuuehd",
                        User = new ApplicationUser() { UserName = "gvjshdgkjsd" }
                    },
                },
                Votes = new List<Vote>()
                {
                    new Vote()
                    {
                        VoteValue = 3,
                        User = new ApplicationUser() { UserName = "qtyqrwtvdb" }
                    },
                },
            };
        }
        #endregion
    }
}
