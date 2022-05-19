using ClothesWebNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWebNET.Controllers
{
    // ngoc phu
    public class CartController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            //ngocphu
            return cart;
        }
        [HttpPost]
        public ActionResult AddtoCart(String id, FormCollection form)
        {
            String size = form["Size"];
            var pro = db.Products.SingleOrDefault(s => s.idProduct == id);
            if (pro != null)
            {
                GetCart().AddCart(pro, size);
            }
            return RedirectToAction("ShowToCart", "Cart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Products");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult UpdateQtyCart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            String id_product = form["ID_Product"];
            int qty = int.Parse(form["Qty"]);
            cart.UpdateQtyShopping(id_product, qty);
            return RedirectToAction("ShowToCart", "Cart");
        }
        [HttpPost]
        public ActionResult DeleteCartItem(String id, FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.RemoveCartItem(id);

            String detail = form["Detail"];
            if (detail != null)
            {
                return RedirectToAction("DetailCart", "Cart");
            }
            else
            {
                return RedirectToAction("ShowToCart", "Cart");
            }
        }
        public ActionResult DetailCart()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Products");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public PartialViewResult BagCart()
        {
            int totalItem = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                totalItem = cart.CartCount();
            ViewBag.QtyCart = totalItem;
            return PartialView("BagCart");
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
    }
}
