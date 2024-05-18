using Cake_shop.Models;
using Cake_shop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private CakeShopDB _dbConnect = new CakeShopDB();
        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            var pageSize = 4;
            if(page == null)
            {
                page = 1;
            }
            var totalCount = _dbConnect.Products.Count();
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var items = _dbConnect.Products.OrderByDescending(x => x.id).Include(p => p.Category).Include(q => q.ProductImages).ToPagedList(pageIndex, pageSize);
            ViewBag.TotalCount = totalCount;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(_dbConnect.Category.ToList(), "id", "name");// cái này là lấy danh mục sản phẩm để hiển thị ra trên thanh chọn
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductModel model, List<string> Images, List<int> rDefault)
        {
            if(ModelState.IsValid)
            {
                if(Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        if(i + 1 == rDefault[0])
                        {
                            model.img = Images[i];
                            model.ProductImages.Add(new GaleryModels
                            {
                                Products_id = model.id,
                                thumbnail = Images[i].ToString(),
                                isDefault = true,
                            });
                        }
                        else
                        {
                            model.ProductImages.Add(new GaleryModels
                            {
                                Products_id = model.id,
                                thumbnail = Images[i].ToString(),
                                isDefault = false,
                            });
                        }
                    }
                }
                model.createDate = DateTime.Now;
                model.modifiedDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);
                _dbConnect.Products.Add(model);
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategory = new SelectList(_dbConnect.Category.ToList(), "id", "name");
            return View(model);
        }
        public ActionResult Edit(long id)
        {
            ViewBag.ProductCategory = new SelectList(_dbConnect.Category.ToList(), "id", "name");// cái này là lấy danh mục sản phẩm để hiển thị ran trên thanh chọn
            var items = _dbConnect.Products.Find(id);
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model)
        {
            if (ModelState.IsValid)// nếu đủ điều kiện
            {
                model.modifiedDate = DateTime.Now;
                model.createDate = DateTime.Now;
                model.alias = Cake_shop.Models.Commnon.Filter.FilterChar(model.title);
                _dbConnect.Products.Attach(model);
                _dbConnect.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var items = _dbConnect.Products.Find(id);
            if (items != null)
            {
                // Xóa các bản ghi liên quan từ bảng phụ trước
                var relatedItems = _dbConnect.Galerys.Where(x => x.Products_id == items.id);
                _dbConnect.Galerys.RemoveRange(relatedItems);

                // Sau đó mới xóa bản ghi từ bảng chính
                _dbConnect.Products.Remove(items);
                _dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }
    }
}