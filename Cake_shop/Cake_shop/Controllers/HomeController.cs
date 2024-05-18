using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cake_shop.Controllers
{
    public class HomeController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        public HomeController() 
        {

        }
        public ActionResult Index()
        {
            var items = _db.Products.Include(p => p.Category).Include(q => q.ProductImages).ToList();
            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Users.FirstOrDefault(u => u.email == user.email);
                if (check == null)
                {
                    user.status = 1;
                    user.Roles_id = 2;
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    ViewBag.Message = "Đăng ký thành công!";
                    return View();
                }
                else
                {
                    ViewBag.error = "Tài khoản đã tồn tại !";
                    return View();
                }
            }
            return View();
        }

    }
}
