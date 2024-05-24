using Cake_shop.Models;
using Cake_shop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 4;

            var items = _db.Orsers.OrderByDescending(x => x.createDate).ToList();
            var pagedProducts = items.ToPagedList(pageNumber, pageSize);  
            return View(pagedProducts);
        }

        public ActionResult Views(long id)
        {

            var order = _db.Orsers.Find(id);
            return View(order);
        }

        public ActionResult Partial_SanPham(long id)
        {
            var items = _db.OrderDetails.Where(x => x.Oders_id == id).ToList();
            return PartialView(items);
        }
        [HttpPost]
        public ActionResult UpdateTT(long id, int trangthai)
        {
            var item = _db.Orsers.Find(id);
            if(item != null)
            {
                _db.Orsers.Attach(item);
                item.payment_methods = trangthai;
                _db.Entry(item).Property(x => x.payment_methods).IsModified = true;
                _db.SaveChanges();
                return Json(new {mesage = "Success", success = true});
            }
            return Json(new { mesage = "UnSuccess", success = false });
        }
    }
}