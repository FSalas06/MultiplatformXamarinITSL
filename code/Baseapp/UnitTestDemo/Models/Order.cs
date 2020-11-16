﻿using System.Collections.Generic;

namespace UnitTestDemo.Models
{
    public class Order
    {
        public string OrderId { get; set; }

        public decimal OrderTotal { get; set; }

        public List<Pie> Pies { get; set; }

        public Address Address { get; set; }

        public string UserId { get; set; }
    }
}
