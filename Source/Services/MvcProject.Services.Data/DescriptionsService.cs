﻿namespace MvcProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MvcProject.Data.DbAccessConfig.Repositories;
    using MvcProject.Data.Models;
    using Web;

    public class DescriptionsService : BaseDataService<Description, int, IIntPKDeletableRepository<Description>>, IDescriptionsService
    {
        public DescriptionsService(IIntPKDeletableRepository<Description> descriptions, IIdentifierProvider idProvider)
            : base(descriptions, idProvider)
        {
        }

        public override Description GetByEncodedId(string id)
        {
            var description = this.Repository.GetById(this.IdentifierProvider.DecodeIdToInt(id));
            return description;
        }

        public override Description GetByEncodedIdFromNotDeleted(string id)
        {
            var description = this.Repository.GetByIdFromNotDeleted(this.IdentifierProvider.DecodeIdToInt(id));
            return description;
        }
    }
}