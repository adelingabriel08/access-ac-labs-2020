﻿using Infrastructure.Free;
using LanguageExt;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.ChangeQuantityOp.ChangeQuantityResult;

namespace Domain.Domain.ChangeQuantityOp
{
    internal class ChangeQuantityOp : OpInterpreter<ChangeQuantityCmd, IChangeQuantityResult, Unit>
    {
        public override Task<IChangeQuantityResult> Work(ChangeQuantityCmd Op, Unit state)
        {
            (bool CommandIsValid, String Error) = Op.IsValid();

            if (CommandIsValid)
            {
                Op.ClientAgg.Cart.CartItems.FirstOrDefault(ci => ci == Op.CartItem).Quantity = Op.NewQuantity;
                return Task.FromResult<IChangeQuantityResult>(new QuantityChanged());
            }
            else
            {
                return Task.FromResult<IChangeQuantityResult>(new QuantityNotChanged(Error));
            }
        }
    }
}