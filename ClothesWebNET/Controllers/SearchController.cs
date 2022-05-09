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
    public class SearchController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        // GET:  http://localhost:46418/search/indexq?=tin
        public ActionResult Index(string q)
        {
            // queryparamater = "glasses";
            ProductDTODetail productDTO = new ProductDTODetail();


            q = q.ToLower();
         
           var productList = (from s in db.Products
                               where s.nameProduct.ToLower().Contains(q)
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();

            return View(query.ToList());
        

        }

        // GET: Search/Details/5
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
                var listProduct = from p in product
                                  join image in db.ImageProducts on p.idProduct equals image.idProduct
                                  join type in db.Types on p.idType equals type.idType
                                  select new ProductDTODetail()
                                  {
                                      idProduct = p.idProduct,
                                      type = type.nameType,
                                      nameProduct = p.nameProduct,
                                      price = p.price,
                                      URLImage = image.URLImage,
                                      sizeL = p.sizeL,
                                      sizeM = p.sizeM,
                                      sizeXL = p.sizeXL,
                                  };

                ViewBag.List = listProduct;
                return View(listProduct.ToList());
            }

        }

        // GET: Search/Create
        public ActionResult Create()
        {
            ViewBag.idType = new SelectList(db.Types, "idType", "nameType");
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
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

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
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

        // POST: Search/Delete/5
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
    }
}
