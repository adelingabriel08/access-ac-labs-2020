﻿using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices.Attributes;
using Domain.Models;
using System.Threading.Tasks;

namespace Domain.Domain.CreateRestauratOp
{
    [AsChoice]
    public static partial class CreateRestaurantResult
    {
        public interface ICreateRestaurantResult { }

        public class RestaurantCreated : ICreateRestaurantResult
        {
            public Restaurant Restaurant { get; }

            public RestaurantCreated(Restaurant restaurant)
            {
                Restaurant = restaurant;
            }
        }


        public class EmptyNameRestaurantNotCreated : ICreateRestaurantResult
        {
            public string Reason { get; }

            public EmptyNameRestaurantNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
