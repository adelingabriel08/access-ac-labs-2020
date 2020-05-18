﻿using Domain.Models;
using Infrastructure.Free;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.Domain.CreateMenuItemOp.CreateMenuItemAndAddToMenuResult;

namespace Domain.Domain.CreateMenuItemOp
{
    public class CreateMenuItemAndAddToMenuOp : OpInterpreter<CreateMenuItemAndAddToMenuCmd, ICreateMenuItemResult, Unit>
    {
        public override Task<ICreateMenuItemResult> Work(CreateMenuItemAndAddToMenuCmd Op, Unit state)
        {
            //validate
            if(Op.Price < 0)
            {
                return Task.FromResult<ICreateMenuItemResult>(new MenuItemNotCreated("price cannot be negative"));
            }

            MenuItem menuItem = new MenuItem(Op.Menu, Op.Name, Op.Price, Op.Ingredients);
            Op.Menu.MenuItems.Add(menuItem);

            return Task.FromResult<ICreateMenuItemResult>(new MenuItemCreated(menuItem));
        }
    }
 }
