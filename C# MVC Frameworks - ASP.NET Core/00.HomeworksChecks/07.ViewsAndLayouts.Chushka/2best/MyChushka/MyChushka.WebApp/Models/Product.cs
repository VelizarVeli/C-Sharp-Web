﻿using System;
using System.Collections.Generic;
using MyChushka.WebApp.Models.Enums;

namespace MyChushka.WebApp.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public ProductType Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}