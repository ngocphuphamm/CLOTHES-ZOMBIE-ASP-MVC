using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesWebNET.Models;

namespace ClothesWebNET.Controllers
{
    public class CollectionsController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        // GET: Collections
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Type);
            return View(products.ToList());
        }

        // GET: Collections/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
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

        // POST: Collections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nameProduct,idProduct,sizeM,sizeL,sizeXL,price,description,idType")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idType = new SelectList(db.Types, "idType", "nameType", product.idType);
            return View(product);
        }

        // GET: Collections/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.idType = new SelectList(db.Types, "idType", "nameType", product.idType);
            return View(product);
        }

        // POST: Collections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nameProduct,idProduct,sizeM,sizeL,sizeXL,price,description,idType")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idType = new SelectList(db.Types, "idType", "nameType", product.idType);
            return View(product);
        }

        // GET: Collections/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Collections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);

            return View(listProduct);

        }

        // collections/aothun
        public ActionResult aothun(string id)
        {
            id = "T02";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);
        }

        // collections/sweater
        public ActionResult sweater(string id)
        {
            id = "T03";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }

        // collections/quan
        public ActionResult quan(string id)
        {
            id = "T05";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }


        // collections/quandai
        public ActionResult quandai(string id)
        {
            id = "T06";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }


        // collections/quanngan
        public ActionResult quanngan(string id)
        {
            id = "T07";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }


        // collections/phukien
        public ActionResult phukien(string id)
        {
            id = "T08";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }

        // collections/walletchain
        public ActionResult walletchain(string id)
        {
            id = "T09";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }


        // collections/kinh
        public ActionResult kinh(string id)
        {
            id = "T10";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }



        // collections/non
        public ActionResult non(string id)
        {
            id = "T11";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }

        // collections/nhan
        public ActionResult nhan(string id)
        {
            id = "T12";
            var listProduct = (from s in db.Products
                               where s.idType == id
                               select s);
            return View(listProduct);

        }

    }
}
