using ClothesWebNET.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWebNET.Controllers
{
    public class HomeController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        // GET: Home
        public ActionResult Index( )
        {
            string  id = "T01";

            var productList = (from s in db.Product
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);

           string idPant = "T05";
            var pantList = (from s in db.Product
                               where s.idType == idPant
                             select s);

            var queryPant = pantList.Include(p => p.ImageProducts);


            ViewBag.list = query.ToList();
         
            ViewBag.listPant = queryPant.ToList();
            


           
            return View(query.ToList());
          
        }
    }
}