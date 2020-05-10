﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.ChangeQuantityOp
{
    public struct ChangeQuantityCmd
    {
        public ClientAgg ClientAgg { get; }
        public CartItem CartItem { get; }
        public uint NewQuantity { get; }

        public ChangeQuantityCmd(ClientAgg clientAgg, CartItem item, uint quantity)
        {
            CartItem = item;
            NewQuantity = quantity;
            ClientAgg = clientAgg;
        }

        public (bool, String) IsValid()
        {
            if (CartItem == null)
                return (false, "No Cart Item Selected");
            if (NewQuantity < 0)
                return (false, "Quantity can't be negative");

            // TODO: Something about the code below
            //if (AllHardcodedValues.HarcodedVals.Carts[SessionID].Status > Cart.CartStatus.PendingOrder && CartItem.Quantity < NewQuantity)
            //return (false, "You cannot reduce the quantity of this item anymore");

            return (true, "None");
        }
    }
}