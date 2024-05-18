using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cake_shop.Controllers
{
    public class MenuController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = _db.Menus.OrderBy(x => x.id).ToList();
            return PartialView("~/Views/Menu/MenuTop.cshtml", items);
        }

    }
}