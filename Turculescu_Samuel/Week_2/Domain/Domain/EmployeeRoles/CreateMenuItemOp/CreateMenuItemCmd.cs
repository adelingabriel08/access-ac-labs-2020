﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.EmployeeRoles.CreateMenuItemOp
{
    public struct CreateMenuItemCmd
    {
        public Menu Menu { get; }
        public string Name { get; }
        public double Price { get; }
        public uint Quantity { get; }
        public string Ingredients { get; }
        public string Allergens { get; }
        public MenuItemState MenuItemState { get; }

        public CreateMenuItemCmd(Menu menu, string name, double price, uint quantity, string ingredients, string allergens, MenuItemState menuItemState)
        {
            Menu = menu;
            Name = name;
            Price = price;
            Quantity = quantity;
            Ingredients = ingredients;
            Allergens = allergens;
            MenuItemState = menuItemState;
        }
    }
}
