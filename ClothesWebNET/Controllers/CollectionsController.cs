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
            var query = db.Product.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }

        // GET: Collections/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
                    
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Collections/Create
        public ActionResult Create()
        {
            ViewBag.idType = new SelectList(db.Types, "idType", "nameType");
            return View();
        }



        // GET: Collections/Edit/5
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        // collections/ao
        public ActionResult ao(string id)
        {
            id = "T01";


         
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
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
            var productList = (from s in db.Product
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());
        }

    }
}
