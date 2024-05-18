using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Areas.Admin.Controllers
{
   
    public class PostController : Controller
    {
        private CakeShopDB _dbConnect = new CakeShopDB();
        // GET: Admin/Post
        public ActionResult Index()
        {
            var items = _dbConnect.Posts.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Post model)
        {
            if (ModelState.IsValid)
            {
                model.createDate = DateTime.Now;
                model.modifiedDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);
                _dbConnect.Posts.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }

        public ActionResult Edit(long id)
        {
            var items = _dbConnect.Posts.Find(Convert.ToInt64(id));// tìm cái model có id này rồi truyền lên view để edit
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post model)
        {
            if (ModelState.IsValid)// nếu đủ điều kiện
            {
                _dbConnect.Posts.Attach(model);
                model.modifiedDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);
                _dbConnect.Entry(model).Property(x => x.title).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.description).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.detail).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.image).IsModified = true;
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
            var items = _dbConnect.Posts.Find(id);
            if (items != null)
            {
                _dbConnect.Posts.Remove(items);
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
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = _dbConnect.Posts.Find(Convert.ToInt32(item));
                        _dbConnect.Posts.Remove(obj);
                        _dbConnect.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}