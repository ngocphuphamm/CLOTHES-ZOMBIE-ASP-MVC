using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesWebNET.Models;
using System.IO;

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
        public ActionResult Create([Bind(Include = "nameProduct,idProduct,sizeM,sizeL,sizeXL,price,description,idType")] Product product, HttpPostedFileBase img1, HttpPostedFileBase img2)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                var idProduct = product.idProduct = Guid.NewGuid().ToString();
                if (ModelState.IsValid)
                {
                    var idImage = Guid.NewGuid().ToString();
                    var idImage2 = Guid.NewGuid().ToString();
                    string _FileName = "";
                    string _FileName2 = "";
                
                    int index = img1.FileName.IndexOf('.');
                    int index2 = img2.FileName.IndexOf('.');
                    _FileName = idImage.ToString() + "." + img1.FileName.Substring(index + 1);
                    _FileName2 = idImage2.ToString() + "." + img2.FileName.Substring(index2 + 1);
                    string _path = Path.Combine(Server.MapPath("~/images/"), _FileName);
                    string _path2 = Path.Combine(Server.MapPath("~/images/"), _FileName2);
                    img1.SaveAs(_path);
                    img2.SaveAs(_path2);
                    
                    db.Products.Add(product);
                    for (var i = 0; i < 2; i++)
                    {
                        if (i % 2 == 0)
                        {
                            var URLimg1 = $"/images/{_FileName}";
                            var image = new ImageProduct()
                            {
                                idImage = idImage,
                                idProduct = idProduct,
                                URLImage = URLimg1

                            };
                            db.ImageProducts.Add(image);
                        }
                        else
                        {
                            var URLimg2 = $"/images/{_FileName2}";
                            var image = new ImageProduct()
                            {
                                idImage = idImage2,
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
        public ActionResult Edit([Bind(Include = "nameProduct,idProduct,sizeM,sizeL,sizeXL,price,description,idType")] Product product ,HttpPostedFileBase img1, HttpPostedFileBase img2)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();

                    var delImages = db.ImageProducts.Where(s => s.idProduct.Equals(product.idProduct));
                    if (delImages != null)
                    {
                        foreach (var image in delImages)
                        {
                            db.ImageProducts.Remove(image);
                        }
                    }
                    db.SaveChanges();

                    var idImage = Guid.NewGuid().ToString();
                    var idImage2 = Guid.NewGuid().ToString();
                    string _FileName = "";
                    string _FileName2 = "";

                    int index = img1.FileName.IndexOf('.');
                    int index2 = img2.FileName.IndexOf('.');
                    _FileName = idImage.ToString() + "." + img1.FileName.Substring(index + 1);
                    _FileName2 = idImage2.ToString() + "." + img2.FileName.Substring(index2 + 1);
                    string _path = Path.Combine(Server.MapPath("~/images/"), _FileName);
                    string _path2 = Path.Combine(Server.MapPath("~/images/"), _FileName2);
                    img1.SaveAs(_path);
                    img2.SaveAs(_path2);

                    for (var i = 0; i < 2; i++)
                    {
                        if (i % 2 == 0)
                        {
                            var URLimg1 = $"/images/{_FileName}";
                            var image = new ImageProduct()
                            {
                                idImage = idImage,
                                idProduct = product.idProduct,
                                URLImage = URLimg1

                            };
                            db.ImageProducts.Add(image);
                        }
                        else
                        {
                            var URLimg2 = $"/images/{_FileName2}";
                            var image = new ImageProduct()
                            {
                                idImage = idImage2,
                                idProduct = product.idProduct,
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
            return Redirect("~/Home");
        }


        
        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                try
                {

                    var delImages = db.ImageProducts.Where(s => s.idProduct.Equals(id));
                    if (delImages != null)
                    {
                        foreach (var image in delImages)
                        {
                            db.ImageProducts.Remove(image);
                        }
                    }
                    Product product = db.Products.Find(id);
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return Json(true);
                }
                catch
                {
                    return Content("Error");
                }
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
