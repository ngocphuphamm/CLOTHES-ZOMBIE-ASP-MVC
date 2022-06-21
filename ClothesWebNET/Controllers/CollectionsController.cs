using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesWebNET.Models;
using static ClothesWebNET.Models.Product;

namespace ClothesWebNET.Controllers
{
    public class CollectionsController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        // GET: Collections
        public ActionResult Index()
        {
            var query = db.Products.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());

        }

        // GET: Collections/Details/5
  
        public ActionResult Details(string id)
        {
            ProductDTODetail productDTO = new ProductDTODetail();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = from el in db.Products
                          where el.idProduct == id
                          select el;

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {

                var data = from p in product
                           select p;

                data.Include("ImageProducts").Include("Type");
                var datarelateto = (from p in db.Products
                                    join t in data on p.idType equals t.idType
                                    select p);
                datarelateto.Include("ImageProducts").Include("Type");
                var subData = (datarelateto.ToList()).Skip(3).Take(4);
                ViewBag.datarelateto = subData.ToList();
                ViewBag.List = data;
                return View(data.ToList());
            };
        }


        // collections/ao
        public ActionResult ao(string id)
        {
            id = "T02";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());


        }

        // collections/aothun
        public ActionResult aothun(string id)
        {
            id = "T02";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }

        // collections/sweater
        public ActionResult sweater(string id)
        {
            id = "T03";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());

        }

        // collections/quan
        public ActionResult quan(string id)
        {
            id = "T05";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }


        // collections/quandai
        public ActionResult quandai(string id)
        {
            id = "T06";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }


        // collections/quanngan
        public ActionResult quanngan(string id)
        {
            id = "T07";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());

        }


        // collections/phukien
        public ActionResult phukien(string id)
        {
            id = "T08";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());

        }

        // collections/walletchain
        public ActionResult walletchain(string id)
        {
            id = "T09";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }


        // collections/kinh
        public ActionResult kinh(string id)
        {
            id = "T10";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }



        // collections/non
        public ActionResult non(string id)
        {
            id = "T11";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }

        // collections/nhan
        public ActionResult nhan(string id)
        {
            id = "T12";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }

    }
}
