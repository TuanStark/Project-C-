using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cake_shop.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart() 
        { 
            this.Items = new List<ShoppingCartItem>();
        }

        public void AddToCart(ShoppingCartItem item, int quantity)
        {
            var checkExist = Items.FirstOrDefault(x => x.ProductId == item.ProductId);
            if (checkExist != null)
            {
                checkExist.Quantity += quantity;
                checkExist.TotalPrice = checkExist.Price * checkExist.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove(long id)
        {
            var checkExist = Items.SingleOrDefault(x => x.ProductId == id);
            if(checkExist != null)
            {
                Items.Remove(checkExist);
            }
        }
        public void UpdateQuantity(long id, int quantity)
        {
            var checkExist = Items.SingleOrDefault(x => x.ProductId == id);
            if (checkExist != null)
            {
                checkExist.Quantity = quantity;
                checkExist.TotalPrice = checkExist.Price * checkExist.Quantity;
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.TotalPrice);
        }
        public decimal GetTotalquanTity()
        {
            return Items.Sum(x => x.Quantity);
        }
        public void clearCart()
        {
            Items.Clear();
        }
    }

    public class ShoppingCartItem
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Alias { get; set; }
        public string CategoryName { get; set; }
        public string ProductImg { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        
    }
}