using Cake_shop.Models;
using Cake_shop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Cake_shop.Controllers
{
    public class ProductsController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        // GET: Products
        public ActionResult Index(int? page)
        {
            var pageSize =2;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = _db.Products.OrderByDescending(x => x.id).Include(p => p.Category).Include(q => q.ProductImages).ToPagedList(pageIndex, pageSize);
            return View(items);
        }

        public ActionResult ProductsDetails(long id) 
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var galleryImages = _db.Galerys.Where(g => g.Products_id == id).ToList();
            var similarProducts = _db.Products.Where(p => p.CategoryId == product.CategoryId && p.id != product.id).Include(t => t.ProductImages).ToList();

            var model = new ProductDetailsViewModel
            {
                Product = product,
                Galery = galleryImages,
                SimilarProducts = similarProducts
            };

            return View(model);
        }
        public ActionResult getAllProduct(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;

            var listProduct = _db.Products.ToList();
            var pagedProducts = listProduct.ToPagedList(pageNumber, pageSize);

            return View(pagedProducts);
        }
    }
}