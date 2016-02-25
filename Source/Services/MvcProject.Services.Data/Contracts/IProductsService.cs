﻿namespace MvcProject.Services.Data
{
    using System.Linq;
    using MvcProject.Data.Models;

    public interface IProductsService
    {
        IQueryable<Product> GetAllProducts();

        IQueryable<Product> GetRandomProducts(int count);

        Product GetById(string id);
    }
}