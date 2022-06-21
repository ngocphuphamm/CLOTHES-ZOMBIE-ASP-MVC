using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothesWebNET.Models
{
    public class CartItem
    {
        public Product _shopping_product { get; set; }
        public int _shopping_qty { get; set; }
        public String _shopping_size { get; set; 
        }
    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void AddCart(Product pro, String size, int qty = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.idProduct == pro.idProduct);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_product = pro,
                    _shopping_qty = qty,
                    _shopping_size = size
                });
            }
            else
            {
                item._shopping_qty += qty;
            }
        }

        public void UpdateQtyShopping(String id, int qty)
        {
            var item = items.Find(s => s._shopping_product.idProduct == id);
            if (item != null)
            {
                item._shopping_qty = qty;
            }
        }

        public int TotalMoney()
        {
            var total = items.Sum(s => s._shopping_product.price * s._shopping_qty);
            return (int)total;
        }

        public void RemoveCartItem(String id)
        {
            items.RemoveAll(s => s._shopping_product.idProduct == id);
        }

        public int CartCount()
        {
            return items.Sum(s => s._shopping_qty);
        }

        public void ClearCart()
        {
            items.Clear();
        }
    }
}