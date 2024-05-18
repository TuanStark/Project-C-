using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Controllers
{
    public class PostController : Controller
    {
        private CakeShopDB db = new CakeShopDB();
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PostPage() 
        {
            var items = db.Posts.Take(4).ToList();
            return View(items);
        }

        public ActionResult PostDetail(long id)
        {
            var items = db.Posts.Find(id);
            return View(items);
        }
    }
}