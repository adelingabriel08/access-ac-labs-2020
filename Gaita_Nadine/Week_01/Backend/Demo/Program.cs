﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Domain.CreateRestauratOp;
using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using static Domain.Domain.CreateMenuOp.CreateMenuAndAddToRestaurantResult;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.CreateIngredientOp.CreateIngredientResult;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOperations(typeof(Restaurant).Assembly);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var expr =
                from restaurantResult1 in RestaurantDomain.CreateRestaurant("Homemade")
                let restaurant1 = (restaurantResult1 as RestaurantCreated)?.Restaurant
                from menuResult1 in RestaurantDomain.CreateMenuAndAddToRestaurant(restaurant1, "Paste", MenuType.Pasta)
                let menu1 = (menuResult1 as MenuCreated)?.Menu
                from ingredientsResult1 in RestaurantDomain.CreateIngredient(3, new List<string>() { "smantana", "bacon", "ceapa" })
                let ingredients1 = (ingredientsResult1 as IngredientCreated)?.Ingredients
                from menuItemResult1 in RestaurantDomain.CreateMenuItemAndAddToMenu(menu1, "Paste carbonara", 27, ingredients1)
                select restaurantResult1;

            var interpreter = new LiveInterpreterAsync(serviceProvider);

            var result = await interpreter.Interpret(expr, Unit.Default);

            var finalResult = result.Match<bool>(OnRestaurantCreated, OnRestaurantNotCreated);
            Assert.True(finalResult);

            Console.WriteLine("Hello World!");
        }

        private static bool OnRestaurantNotCreated(RestaurantNotCreated arg)
        {
            return false;
        }

        private static bool OnRestaurantCreated(RestaurantCreated arg)
        {
            return true;
        }
    }
}
