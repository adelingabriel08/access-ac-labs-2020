﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Queries;
using Infrastructure.Free;
using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.EfCore;
using static Domain.Domain.CreateRestaurantOp.CreateRestaurantResult;

namespace Domain.Domain.CreateRestaurantOp
{
    public class CreateRestaurantOp : OpInterpreter<CreateRestaurantCmd, CreateRestaurantResult.ICreateRestaurantResult, Unit>
    {
        private readonly IServiceProvider _serviceProvider;

        public CreateRestaurantOp(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public override Task<ICreateRestaurantResult> Work(CreateRestaurantCmd Op, Unit state)
       {
           RestaurantAgg newRestaurantAgg = new RestaurantAgg(new Restaurant() { Name = Op.Name, Address = Op.Address });
                
           return Task.FromResult<ICreateRestaurantResult>(new RestaurantCreated(newRestaurantAgg));                                       
        }
    }
}
