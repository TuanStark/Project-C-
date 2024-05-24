using Cake_shop.Models;
using Cake_shop.Models.EF;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cake_shop.Controllers
{
    public class CartController : Controller
    {
        private CakeShopDB _db = new CakeShopDB();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial_Item_ThanhToan()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }
        public ActionResult Partial_ItemCart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return PartialView(cart.Items);
            }
            return PartialView();
        }

        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items != null)
            {
                return Json(new { count = cart.Items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { count = 0 }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Partial_CheckOut()
        {
            return PartialView();
        }
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.Checkcart = cart;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(OrderViewModel req)
        {
            var response = new { Success = false, Code = -1};

            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null && cart.Items.Any())
                {
                    var productIds = cart.Items.Select(x => x.ProductId).ToList();
                    var validProductIds = _db.Products.Where(p => productIds.Contains(p.id)).Select(p => p.id).ToList();
                    OdersModel order = new OdersModel();
                    order.fullName = req.CustomerName;
                    order.phone = req.Phone;
                    order.email = req.Email;
                    order.address = req.Address;
                    order.Users_id = GetCurrentUserId();
                    order.order_date = DateTime.Now;
                    order.status = 1;
                    order.total_money = (float)cart.Items.Sum(x => (x.Quantity * x.Price));
                    var orderID = order.id;
                    cart.Items.ForEach(x => order.ordersDetails.Add(new OrdersDetails
                    {
                    Oders_id = orderID,
                        
                        ProductId = x.ProductId,
                        quantity = x.Quantity,
                        price = (double)x.Price,
                        total_money = order.total_money
                    }));                   
                    order.payment_methods = req.payment_method;
                    order.createDate = DateTime.Now;
                    order.createBy = req.CustomerName;
                    Random rd = new Random();
                    order.note = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                   
                    _db.Orsers.Add(order);
                    _db.SaveChanges();
                   cart.clearCart();
                    return RedirectToAction("CheckOutSuccess");
                }
            }
            return Json(response);
        }
        private long GetCurrentUserId()
        {
            if (Session["userID"] != null)
            {
                return (long)Session["userID"];
            }
            return -1;
            /*else
            {
                Response.Redirect("DangNhap","Home");
                return -1;
            }*/
        }
        public ActionResult CheckOutSuccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToCart(long id, int quantity)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            if (quantity <= 0)
            {
                return Json(new { Success = false, msg = "Số lượng không hợp lệ", code = -1, count = 0 });
            }

            CakeShopDB db = new CakeShopDB();
            var checkproduct = db.Products.Include("ProductImages").FirstOrDefault(x => x.id == id);
            if (checkproduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem items = new ShoppingCartItem
                {
                    ProductId = checkproduct.id,
                    ProductName = checkproduct.title,
                    CategoryName = checkproduct.Category.name,
                    Alias = checkproduct.alias,
                    Quantity = quantity
                };
                if (checkproduct.ProductImages.FirstOrDefault(x => x.isDefault) != null )
                {
                        items.ProductImg = checkproduct.ProductImages.FirstOrDefault(x => x.isDefault).thumbnail;

                }
                items.Price = (decimal)checkproduct.price;
                if (checkproduct.discount > 0)
                {
                    var discountAmount = ((decimal)checkproduct.discount / 100) * items.Price;
                    items.Price -= discountAmount;
                }
                items.TotalPrice = items.Price * items.Quantity;
                cart.AddToCart(items, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công!", code = 1, count = cart.Items.Count };
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult Update(long id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                /*var checkProduct = cart.Items.FirstOrDefault(x => x.ProductId == id);*/
                if (cart != null)
                {
                    cart.UpdateQuantity(id,quantity);
                    return Json(new { Success = true });
                }
            }
            return  Json(new { Success = false });
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                var checkProduct = cart.Items.FirstOrDefault(x => x.ProductId == id);
                if(checkProduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, count = cart.Items.Count  };
                }
            }
            return Json(code);
        }

        
    }
}