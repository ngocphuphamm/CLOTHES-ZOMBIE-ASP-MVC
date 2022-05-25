using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesWebNET.Models;

namespace ClothesWebNET.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        // GET: Admin/Products
        public ActionResult Index()
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                var products = db.Products
                    .Include(p => p.Type)
                    .Include(i=>i.ImageProducts);
                return View(products.ToList());
            }
            return Redirect("~/login");
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
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
            return Redirect("~/login");
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                ViewBag.idType = new SelectList(db.Types, "idType", "nameType");
                return View();
            }
            return Redirect("~/login");
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nameProduct,idProduct,sizeM,sizeL,sizeXL,price,description,idType")] Product product, string URLimg1, string URLimg2)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                var idProduct = product.idProduct = Guid.NewGuid().ToString();
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    for (var i = 0; i < 2; i++)
                    {
                        if (i % 2 == 0)
                        {
                            var image = new ImageProduct()
                            {
                                idImage = Guid.NewGuid().ToString(),
                                idProduct = idProduct,
                                URLImage = URLimg1

                            };
                            db.ImageProducts.Add(image);
                        }
                        else
                        {
                            var image = new ImageProduct()
                            {
                                idImage = Guid.NewGuid().ToString(),
                                idProduct = idProduct,
                                URLImage = URLimg2

                            };
                            db.ImageProducts.Add(image);
                        }

                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.idType = new SelectList(db.Types, "idType", "nameType", product.idType);
                return View(product);
            }
            return Redirect("~/Login");
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
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
            return Redirect("~/login");
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nameProduct,idProduct,sizeM,sizeL,sizeXL,price,description,idType")] Product product)
        {
           
            if (Session["SESSION_GROUP_ADMIN"] != null)
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
            return Redirect("~/login");
        }


        // GET: Admin/Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
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
            return Redirect("~/login");
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Redirect("~/login");
        }

        protected override void Dispose(bool disposing)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        
        }
    }
}
