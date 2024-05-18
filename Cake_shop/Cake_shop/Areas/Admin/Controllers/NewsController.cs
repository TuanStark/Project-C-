using Cake_shop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private CakeShopDB _dbConnect = new CakeShopDB();
        // GET: Admin/News
        public ActionResult Index(int? page, string searchtext)
        {
            var pageSize = 4;
            if(page == null)
            {
                page = 1;
            }
            IEnumerable<NewsModel> items = _dbConnect.News.OrderByDescending(x => x.id);
            if (!string.IsNullOrEmpty(searchtext))
            {
                items = items.Where(x => x.alias.Contains(searchtext)|| x.title.Contains(searchtext));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex,pageSize);
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(items);
        }
        public ActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NewsModel model) {
            if(ModelState.IsValid)
            {
                model.createDate = DateTime.Now;
                model.modifiedDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);
                _dbConnect.News.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public ActionResult Edit(long id)
        {
            var items = _dbConnect.News.Find(id);// tìm cái model có id này rồi truyền lên view để edit
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsModel model)
        {
            if (ModelState.IsValid)// nếu đủ điều kiện
            {
                _dbConnect.News.Attach(model);
                model.modifiedDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);
                _dbConnect.Entry(model).Property(x => x.title).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.content).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.sumary).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.img).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.alias).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.modifiedDate).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.modifiledBy).IsModified = true;
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var items = _dbConnect.News.Find(id);
            if(items != null)
            {
                _dbConnect.News.Remove(items);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items =ids.Split(',');
                if(items != null && items.Any()) 
                {
                    foreach (var item in items)  
                    {
                        var obj = _dbConnect.News.Find(Convert.ToInt32(item));
                        _dbConnect.News.Remove(obj);
                        _dbConnect.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}