﻿namespace JustOrderIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using JustOrderIt.Data.DbAccessConfig.Repositories;
    using JustOrderIt.Data.Models.Orders;
    using Web;

    public class OrdersService : BaseDataService<Order, int, IIntPKDeletableRepository<Order>>, IOrdersService
    {
        public OrdersService(IIntPKDeletableRepository<Order> orders, IIdentifierProvider idProvider)
            : base(orders, idProvider)
        {
        }

        public override Order GetByEncodedId(string id)
        {
            var order = this.Repository.GetById((int)this.IdentifierProvider.DecodeToIntId(id));
            return order;
        }

        public override Order GetByEncodedIdFromNotDeleted(string id)
        {
            var order = this.Repository.GetByIdFromNotDeleted((int)this.IdentifierProvider.DecodeToIntId(id));
            return order;
        }
    }
}
