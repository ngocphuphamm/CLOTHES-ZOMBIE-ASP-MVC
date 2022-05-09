using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWebNET.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
           

           if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                return View();
            }
            return Redirect("~/Home");

        }
    }
}