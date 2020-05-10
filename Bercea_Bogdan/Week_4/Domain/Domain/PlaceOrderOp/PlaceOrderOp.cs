﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using static Domain.Domain.PlaceOrderOp.PlaceOrderResult;

namespace Domain.Domain.PlaceOrderOp
{
    public class PlaceOrderOp : OpInterpreter<PlaceOrderCmd, IPlaceOrderResult, Unit>
    {
        public override Task<IPlaceOrderResult> Work(PlaceOrderCmd Op, Unit state)
        {

            var (valid, validationResults) = Op.Validate();
            string validationMessage = "";
            validationResults.ForEach(x => validationMessage += x.ErrorMessage);

            if (!valid)
                return Task.FromResult((IPlaceOrderResult)new OrderNotPlaced(validationMessage));

            Op.Restaurant.AddToIncomingOrders(Op.Order);
            return Task.FromResult((IPlaceOrderResult)new OrderPlaced(Op.Restaurant, Op.Order));
        }
    }
}
