using Cake_shop.Models;
using Cake_shop.Models.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Cake_shop.Areas.Controllers
{
    public class AccountController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PageLogin()
        {
            return View();
        }

        

    }
}