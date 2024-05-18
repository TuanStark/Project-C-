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
            var response = new { Success = false, Code = -1, Message = "Invalid data" };

            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null && cart.Items.Any())
                {
                    OdersModel order = new OdersModel
                    {
                        fullName = req.CustomerName,
                        phone = req.Phone,
                        address = req.Address,
                        email = req.Email,
                        order_date = DateTime.Now,
                        total_money = (float)cart.Items.Sum(x => (x.Price * x.Quantity)),
                        payment_methods = req.payment_method,
                        status = 1,
                        note = $"DH{new Random().Next(1000, 9999)}"
                    };

                    foreach (var item in cart.Items)
                    {
                        var orderDetail = new OrdersDetails
                        {
                            ProductId = item.ProductId,
                            quantity = item.Quantity,
                            price = (double)item.Price
                        };
                        order.ordersDetails.Add(orderDetail);
                    }

                    _db.Orsers.Add(order);
                    _db.SaveChanges();
                   cart.clearCart();
                    return RedirectToAction("CheckOutSuccess");
                }
                else
                {
                    response = new { Success = false, Code = -2, Message = "Cart is empty" };
                }
            }
            return Json(response);
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