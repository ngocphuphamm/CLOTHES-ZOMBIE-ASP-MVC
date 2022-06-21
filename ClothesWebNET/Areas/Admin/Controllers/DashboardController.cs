using ClothesWebNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWebNET.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        // GET: Admin/Dashboard
        public ActionResult Index()
        {


            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                int countUser = db.Users.Count();
                int countBill = db.Bills.Count();
                int countProduct = db.Products.Count();
                ViewBag.countUser = countUser.ToString(); ;
                ViewBag.countBill = countBill.ToString(); ;
                ViewBag.product = countProduct.ToString(); ;
                return View();
            }
            return Redirect("~/login");

        }
    }
}