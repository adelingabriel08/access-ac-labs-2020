﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Free;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using static Domain.Domain.GetOrdersOp.GetOrdersResult;

namespace Domain.Domain.GetOrdersOp
{
    public class GetOrdersOp : OpInterpreter<GetOrdersCmd, GetOrdersResult.IGetOrdersResult, Unit>
    {
        public override Task<IGetOrdersResult> Work(GetOrdersCmd Op, Unit state)
        {
            return (Op.Restaurant.Orders is null) ?
                Task.FromResult<IGetOrdersResult>(new GetOrdersResultNotSuccessful("No orders in this restaurant!")) :
                Task.FromResult<IGetOrdersResult>(new GetOrdersResultSuccessful(Op.Restaurant.Orders));
        }
    }
}
