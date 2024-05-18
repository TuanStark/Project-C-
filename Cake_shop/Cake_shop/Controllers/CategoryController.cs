using Cake_shop.Models;
using Cake_shop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Cake_shop.Controllers
{
    public class CategoryController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductCategory(long id, int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 8;

            var listProduct = _db.Products.Where(n => n.CategoryId == id).ToList();
            var pagedProducts = listProduct.ToPagedList(pageNumber, pageSize);

            return View(pagedProducts);
        }
        public ActionResult MenuProducts()
        {
            var items = _db.Category.ToList();
            return PartialView("MenuProducts", items);
        }
        
    }
}