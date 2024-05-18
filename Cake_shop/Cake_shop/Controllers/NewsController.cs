using Cake_shop.Models;
using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Controllers
{
    public class NewsController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        // GET: News
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult NewsPage()
        {
            var items = _db.News.Take(4).ToList();
            return PartialView("NewsPage", items);
        }
        public ActionResult NewsAndPost()
        {
            var viewModel = new NewsAndPostViewModel
            {
                News = _db.News.ToList(),
                Posts = _db.Posts.ToList()
            };

            return PartialView("NewsAndPost", viewModel);
        }

        public ActionResult NewsDetail(long id) 
        {
            var items = _db.News.Find(id);
            return View(items);
        }
    }
}