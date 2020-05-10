﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design.Serialization;

namespace Domain.Domain.EmployeeRoles.CreateMenuItemOp
{
    public static partial class CreateMenuItemResult
    {
        public interface ICreateMenuItemResult { }

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
