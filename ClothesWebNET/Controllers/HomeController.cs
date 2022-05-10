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
        /// <summary>
        /// ////////////
        /// </summary>
        /// <returns></returns>
        public ActionResult Index( )
        {
            string  id = "T01";
            string idPant = "T05";
            var dataList = (from s in db.Products
                               where (s.idType == idPant || s.idType == id)
                             select s);

            var query = dataList.Include(p => p.ImageProducts);
             return View(query.ToList());
          
        }
    }
}