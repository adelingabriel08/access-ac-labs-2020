﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.EfCore
{
    public partial class Restaurant : IEntity
    {
        public Restaurant()
        {
            Employee = new HashSet<Employee>();
            Menu = new HashSet<Menu>();
            Order = new HashSet<Order>();
        }

        public Restaurant(String name)
        {
            Name = name;
            Employee = new HashSet<Employee>();
            Menu = new HashSet<Menu>();
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}