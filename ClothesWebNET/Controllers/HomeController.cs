using ClothesWebNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWebNET.Controllers
{
    public class HomeController : Controller
    {
        private CLOTHESEntities1 db = new CLOTHESEntities1();

        // GET: Home
        public ActionResult Index()
        {
             return View();
        }
    }
}