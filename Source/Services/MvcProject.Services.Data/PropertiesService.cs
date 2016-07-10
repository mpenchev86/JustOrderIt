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

    public class PropertiesService : BaseDataService<Property, int, IIntPKDeletableRepository<Property>>, IPropertiesService
    {
        private readonly IIntPKDeletableRepository<Property> properties;
        private IIdentifierProvider idProvider;

        public PropertiesService(IIntPKDeletableRepository<Property> properties, IIdentifierProvider idProvider)
            : base(properties, idProvider)
        {
            this.properties = properties;
            this.idProvider = idProvider;
        }

        public override Property GetByEncodedId(string id)
        {
            var idAsInt = this.idProvider.DecodeIdToInt(id);
            var property = this.properties.GetById(idAsInt);
            return property;
        }

        public override Property GetByEncodedIdFromNotDeleted(string id)
        {
            var idAsInt = this.idProvider.DecodeIdToInt(id);
            var property = this.properties.GetByIdFromNotDeleted(idAsInt);
            return property;
        }
    }
}