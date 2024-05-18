﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cake_shop.Models
{
    public class OrderViewModel
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int payment_method { get; set; }
    }
}