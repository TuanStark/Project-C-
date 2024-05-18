using Cake_shop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        CakeShopDB _dbConnect = new CakeShopDB();
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var items = _dbConnect.Menus;
            return View(items);
        }
        public ActionResult Add() 
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Menu model)
        {
            if(ModelState.IsValid)
            {
                model.createDate = DateTime.Now;
                model.modifiedDate = DateTime.Now;
          /*      model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);*/
                _dbConnect.Menus.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(long id)
        {
            var items = _dbConnect.Menus.Find(Convert.ToInt64(id));// tìm cái model có id này rồi truyền lên view để edit
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu model)
        {
            if (ModelState.IsValid)// nếu đủ điều kiện
            {
                _dbConnect.Menus.Attach(model);
                model.modifiedDate = DateTime.Now;
                /*model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);*/
                _dbConnect.Entry(model).Property(x => x.name).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.link).IsModified = true;
/*                _dbConnect.Entry(model).Property(x => x.sumary).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.img).IsModified = true;
                _dbConnect.Entry(model).Property(x => x.alias).IsModified = true;*/
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
            var items = _dbConnect.Menus.Find(Convert.ToInt64(id));
            if (items != null)
            {
                _dbConnect.Menus.Remove(items);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}