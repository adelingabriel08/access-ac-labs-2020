﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Domain.CreateMenuOp;
using Domain.Domain.CreateRestauratOp;
using Domain.Models;
using Infra.Free;
using LanguageExt.ClassInstances;
using static IOExt;
using static Domain.Domain.CreateRestauratOp.CreateRestaurantResult;
using Domain.Domain.CreateMenuItemOp;
using Domain.Domain.GetOp;
using Domain.Domain.CreateClientOp;

namespace Domain.Domain
{
    public static class RestaurantDomain
    {
        public static IO<ICreateRestaurantResult> CreateRestaurant(string name) =>
            NewIO<CreateRestaurantCmd, ICreateRestaurantResult>(new CreateRestaurantCmd(name));

        public static IO<CreateMenuResult.ICreateMenuResult> CreateMenu(Restaurant restaurant, string menuName,
            MenuType menuType)
            => NewIO<CreateMenuCmd, CreateMenuResult.ICreateMenuResult>(new CreateMenuCmd(restaurant, menuName, menuType));

        public static IO<CreateMenuItemResult.ICreateMenuItemResult> CreateMenuItem(Menu menu, string name, uint price) =>
            NewIO<CreateMenuItemCmd, CreateMenuItemResult.ICreateMenuItemResult>(new CreateMenuItemCmd(menu, name, price));

        public static IO<CreateClientResult.ICreateClientResult> CreateClient(List<Client> clients, string name) =>
            NewIO<CreateClientCmd, CreateClientResult.ICreateClientResult>(new CreateClientCmd(clients, name));

        public static IO<GetResultType<T>> Get<T>(List<T> items, Predicate<T> expession) =>
            NewIO<GetCmd<T>, GetResultType<T>>(new GetCmd<T>(items, expession));
    }
}
