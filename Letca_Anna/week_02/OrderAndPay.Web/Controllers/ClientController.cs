﻿using Domain.Domain;
using Domain.Domain.GetRestaurantOp;
using Infrastructure.Free;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Abstractions;
using Persistence.EfCore;
using System.Threading.Tasks;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using static Domain.Domain.GetRestaurantOp.GetRestaurantResult;

namespace OrderAndPay.Web.Controllers
{
    [Route("Client")]
    public class ClientController
    {
        public readonly LiveInterpreterAsync _interpreter;
        public ClientController(LiveInterpreterAsync interpreter)
        {
            _interpreter = interpreter;
        }

        [HttpGet("restaurant/{name}")]
        public async Task<IActionResult> GetRestaurant(string name)
        {
            var getRestaurantExpr =from restaurant in RestaurantDomain.GetRestaurant(name)
                                   select restaurant;

            var result = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            return result.Match(
                found => (IActionResult)new OkObjectResult(found.RestaurantAgg.Restaurant),
                notFound => new NotFoundObjectResult(notFound.Reason));
        }

        [HttpPost("createrestaurant")]
        public async Task<IActionResult> CreateRestaurant([FromBody] Restaurant restaurant)
        {
            var createRestaurantExpr = from entity in RestaurantDomain.CreateRestaurant(restaurant.Name)
                                       let entityRes = (entity as RestaurantCreated)?.RestaurantAgg
                                       from r in Database.AddOrUpdate(entityRes.Restaurant)
                                       select r;

            var result = await _interpreter.Interpret(createRestaurantExpr, Unit.Default);

            return result.Match(
                succesful => (IActionResult)new OkObjectResult(restaurant),
                failed => new NotFoundObjectResult(failed.Reason));
        }

        [HttpGet("{restaurantname}/menus")]
        public async Task<IActionResult> GetMenus(string restaurantname)
        {
            var getRestaurantExpr = from restaurant in RestaurantDomain.GetRestaurant(restaurantname)
                                    select restaurant;

            var result = await _interpreter.Interpret(getRestaurantExpr, Unit.Default);

            return result.Match(
                found => (IActionResult)new OkObjectResult(found.RestaurantAgg.Restaurant.Menus),
                notFound => new NotFoundObjectResult(notFound.Reason));
        }
    }
}
