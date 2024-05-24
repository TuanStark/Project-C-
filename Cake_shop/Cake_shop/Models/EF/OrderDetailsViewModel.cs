using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.EF
{
    public class OrderDetailsViewModel
    {
        public OdersModel Order { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}