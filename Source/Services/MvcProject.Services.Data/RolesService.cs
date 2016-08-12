﻿namespace MvcProject.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using MvcProject.Data.DbAccessConfig.Repositories;
    using MvcProject.Data.Models;
    using Web;

    public class RolesService : BaseDataService<ApplicationRole, string, IStringPKDeletableRepository<ApplicationRole>>, IRolesService
    {
        private readonly RoleManager<ApplicationRole, string> roleManager;

        public RolesService(
            IStringPKDeletableRepository<ApplicationRole> roles,
            IIdentifierProvider idProvider,
            RoleManager<ApplicationRole, string> roleManager)
            : base(roles, idProvider)
        {
            this.roleManager = roleManager;
        }

        public ApplicationRole GetByName(string name)
        {
            return this.roleManager.FindByName(name);
        }

        public override ApplicationRole GetByEncodedId(string id)
        {
            var decodedId = this.IdentifierProvider.DecodeIdToString(id);
            var role = this.Repository.GetById(decodedId);
            return role;
        }

        public override ApplicationRole GetByEncodedIdFromNotDeleted(string id)
        {
            var decodedId = this.IdentifierProvider.DecodeIdToString(id);
            var role = this.Repository.GetByIdFromNotDeleted(decodedId);
            return role;
        }
    }
}
