﻿namespace MvcProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MvcProject.Data.DbAccessConfig.Repositories;
    using MvcProject.Data.Models;
    using MvcProject.Services.Web;

    public class CategoriesService : BaseDataService<Category, int, IIntPKDeletableRepository<Category>>, ICategoriesService
    {
        private readonly IIntPKDeletableRepository<Category> repository;
        private IIdentifierProvider idProvider;

        public CategoriesService(IIntPKDeletableRepository<Category> repository, IIdentifierProvider idProvider)
            : base(repository, idProvider)
        {
            this.repository = repository;
            this.idProvider = idProvider;
        }

        public override Category GetByEncodedId(string id)
        {
            var idAsInt = this.idProvider.DecodeIdToInt(id);
            var category = this.repository.GetById(idAsInt);
            return category;
        }

        public override Category GetByEncodedIdFromNotDeleted(string id)
        {
            var idAsInt = this.idProvider.DecodeIdToInt(id);
            var category = this.repository.GetByIdFromNotDeleted(idAsInt);
            return category;
        }
    }
}
