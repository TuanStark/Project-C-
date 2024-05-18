using Cake_shop.Models.Admin;
using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cake_shop.Models
{
    public class ProductDetailsViewModel
    {
        public List<ProductModel> SimilarProducts { get; set; }
        public ProductModel Product { get; set; }
        public List<GaleryModels> Galery { get; set; }
    }
}