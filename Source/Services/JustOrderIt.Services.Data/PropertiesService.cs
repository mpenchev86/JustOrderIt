﻿namespace JustOrderIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using JustOrderIt.Data.DbAccessConfig.Repositories;
    using JustOrderIt.Data.Models;
    using JustOrderIt.Data.Models.Catalog;
    using JustOrderIt.Services.Web;

    public class PropertiesService : BaseDataService<Property, int, IIntPKDeletableRepository<Property>>, IPropertiesService
    {
        public PropertiesService(IIntPKDeletableRepository<Property> properties, IIdentifierProvider idProvider)
            : base(properties, idProvider)
        {
        }

        public override Property GetByEncodedId(string id)
        {
            var property = this.Repository.GetById((int)this.IdentifierProvider.DecodeToIntId(id));
            return property;
        }

        public override Property GetByEncodedIdFromNotDeleted(string id)
        {
            var property = this.Repository.GetByIdFromNotDeleted((int)this.IdentifierProvider.DecodeToIntId(id));
            return property;
        }
    }
}
