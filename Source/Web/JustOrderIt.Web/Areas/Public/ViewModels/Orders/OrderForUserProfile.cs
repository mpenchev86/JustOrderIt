﻿namespace JustOrderIt.Web.Areas.Public.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using Data.Models.Orders;
    using Infrastructure.Mapping;

    public class OrderForUserProfile : BasePublicViewModel<int>, IMapFrom<Order>
    {
        private ICollection<OrderItemForUserProfile> orderItems;

        public OrderForUserProfile()
        {
            this.orderItems = new List<OrderItemForUserProfile>();
        }

        public Guid RefNumber { get; set; }

        public decimal TotalCost { get; set; }

        public DateTime CreatedOn { get; set; }

        [UIHint("OrderItems")]
        public virtual ICollection<OrderItemForUserProfile> OrderItems
        {
            get { return this.orderItems; }
            set { this.orderItems = value; }
        }
    }
}