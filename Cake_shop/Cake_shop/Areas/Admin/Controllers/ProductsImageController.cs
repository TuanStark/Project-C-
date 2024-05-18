using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Areas.Admin.Controllers
{
    public class ProductsImageController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        // GET: Admin/ProductsImage
        public ActionResult Index(long id )
        {
            ViewBag.ProductID = id;
            var items = _db.Galerys.Where(x => x.Products_id == id).ToList(); 
            return View(items);
        }
        [HttpPost]
        public ActionResult AddImage(long productID, string url)
        {
            _db.Galerys.Add(new GaleryModels
            {
                Products_id = productID,
                thumbnail = url,
                isDefault = false
            });
            _db.SaveChanges();
            return Json(new {Success = true});
        }
        [HttpPost]
        public ActionResult Delete(long id) 
        {
            var item = _db.Galerys.Find(id);
            _db.Galerys.Remove(item);
            _db.SaveChanges();
            return Json(new { Success = true });
        }
    }
}