using Cake_shop.Models;
using Cake_shop.Models.Admin;
using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace Cake_shop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CakeShopDB _dbConnect = new CakeShopDB();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = _dbConnect.Category;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryModel model) 
        { 
            if (ModelState.IsValid)// nếu đủ điều kiện
            {
                model.createDate = DateTime.Now;
                model.modifiedDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.name);
                _dbConnect.Category.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(long id)
        {
            var item = _dbConnect.Category.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel model)
        {
            if (ModelState.IsValid)// nếu đủ điều kiện
            {
                _dbConnect.Category.Attach(model);
                model.modifiedDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.name);
                _dbConnect.Entry(model).Property(x => x.name).IsModified = true;
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
            var item = _dbConnect.Category.Find(id);
            if(item != null)
            {
                /*var Deleteitem = _dbConnect.Category.Attach(item);*/
                _dbConnect.Category.Remove(item);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = true });
        }
    }
}