﻿using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateMenuItemOp
{
    [AsChoice]
    public static partial class CreateMenuItemAndAddToMenuResult
    {
        public interface ICreateMenuItemResult { };
        public class MenuItemCreated : ICreateMenuItemResult
        {
            public MenuItem MenuItem { get; }
            public MenuItemCreated(MenuItem menuItem)
            {
                MenuItem = menuItem;
            }

        }
        public class MenuItemNotCreated : ICreateMenuItemResult
        {
            public string Reason { get; }
            public MenuItemNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
