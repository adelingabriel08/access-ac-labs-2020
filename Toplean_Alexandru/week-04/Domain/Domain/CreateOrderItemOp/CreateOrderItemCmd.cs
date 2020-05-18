﻿using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.CreateOrderItemOp
{
    public class CreateOrderItemCmd
    {
        public OrderItems OrderItem { get; }

        public CreateOrderItemCmd(OrderItems orderItem)
        {
            OrderItem = orderItem;
        }
    }
}