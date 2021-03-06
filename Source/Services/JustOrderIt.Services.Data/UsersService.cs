﻿namespace JustOrderIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    using JustOrderIt.Data.DbAccessConfig;
    using JustOrderIt.Data.DbAccessConfig.Repositories;
    using JustOrderIt.Data.Models;
    using JustOrderIt.Data.Models.Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Web;

    public class UsersService : BaseDataService<ApplicationUser, string, IStringPKDeletableRepository<ApplicationUser>>, IUsersService
    {
        private UserManager<ApplicationUser, string> userManager;

        public UsersService(IStringPKDeletableRepository<ApplicationUser> users, IIdentifierProvider idProvider, UserManager<ApplicationUser, string> userManager)
            : base(users, idProvider)
        {
            this.userManager = userManager;
        }

        public ApplicationUser GetByUserName(string userName)
        {
            var user = this.userManager.FindByName(userName);
            return user;
        }

        public override ApplicationUser GetByEncodedId(string id)
        {
            var decodedId = this.IdentifierProvider.DecodeToStringId(id);
            var user = this.Repository.GetById(decodedId);
            return user;
        }

        public override ApplicationUser GetByEncodedIdFromNotDeleted(string id)
        {
            var decodedId = this.IdentifierProvider.DecodeToStringId(id);
            var user = this.Repository.GetByIdFromNotDeleted(decodedId);
            return user;
        }
    }
}
