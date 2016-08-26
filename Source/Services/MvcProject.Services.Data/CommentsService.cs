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

    public class CommentsService : BaseDataService<Comment, int, IIntPKDeletableRepository<Comment>>, ICommentsService
    {
        public CommentsService(IIntPKDeletableRepository<Comment> comments, IIdentifierProvider idProvider)
            : base(comments, idProvider)
        {
        }

        public override Comment GetByEncodedId(string id)
        {
            var comment = this.Repository.GetById(this.IdentifierProvider.DecodeIdToInt(id));
            return comment;
        }

        public override Comment GetByEncodedIdFromNotDeleted(string id)
        {
            var comment = this.Repository.GetByIdFromNotDeleted(this.IdentifierProvider.DecodeIdToInt(id));
            return comment;
        }
    }
}