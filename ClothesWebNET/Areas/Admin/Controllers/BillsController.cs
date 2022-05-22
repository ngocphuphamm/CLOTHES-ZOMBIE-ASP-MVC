using System;
using System.Collections;
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
    public class BillsController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        [HttpGet]
        public JsonResult GetAllBill()
        {
            ProductDTODetail productDTO = new ProductDTODetail();

            var bills = db.Bills.Include(b => b.User);
            var listProduct = from p in bills
                                 
                                select new BillData()
                               {
                                  idBill = p.idBill,
                                  idUser = p.idUser,
                                  Ship = p.Shipping,
                                  Total = p.Total,
                                  PTTT = p.PTTT,
                                  status = p.status,
                                    createdAt = p.createdAt,
                                  Qty = p.totalQty,
                                  nameUser = p.nameBook,
                                  email = p.email,
                                  phone = p.phone,

                              };
            return Json(listProduct.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDetailBill(string idBill)
        {
          
       
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (idBill == null)
                {
                     return Json("ERR");
                }

                Bill bill = db.Bills.Find(idBill);

                if (bill == null)
                {
                    return Json("Không có hóa đơn này");
                }
                else
                {
                    
                    var billList = (from detail in db.DetailBIlls
                                    where detail.idBill == idBill
                                    join bills in db.Bills on detail.idBill equals bills.idBill
                                    join product in db.Products on detail.idProduct equals product.idProduct
                                    select new ItemDetail()
                                    {
                                        nameBook=bill.nameBook,
                                        phone=bill.phone,
                                        address=bill.address,
                                        idBill=idBill,
                                        nameProduct = product.nameProduct,
                                        qty = detail.qty,
                                        price = product.price,
                                        intoMoney = detail.intoMoney,
                                        Total=bills.Total
                                                                                                                 
                                    });

                
                    return Json(billList);

                }
            }
            return Json("không đủ quyền");







        }
        // GET: Admin/Bills

        public ActionResult Index()
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                var bills = db.Bills.Include(b => b.User);
                return View(bills.ToList());
            }
            return Redirect("~/Home");
        }

        // GET: Admin/Bills/Details/5
        public ActionResult Details(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bill bill = db.Bills.Find(id);
                if (bill == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var billList = (from s in db.Bills
                                       where s.idBill == id
                                       select s);

                    var query = billList.Include(p => p.DetailBIlls);
                    ViewBag.list = query.ToList();
                    return View(query.ToList());
                }
              
            }
            return Redirect("~/login");
        }

        // GET: Admin/Bills/Create
        public ActionResult Create()
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                ViewBag.idUser = new SelectList(db.Users, "idUser", "idPermission");
                return View();
            }
            return Redirect("~/Home");
        }

        // POST: Admin/Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idBill,idUser,Shipping,Total,PTTT,status,createdAt,totalQty,nameBook,email,phone,address")] Bill bill)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Bills.Add(bill);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.idUser = new SelectList(db.Users, "idUser", "idPermission", bill.idUser);
                return View(bill);
            }
            return Redirect("~/Home");
        }

        // GET: Admin/Bills/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bill bill = db.Bills.Find(id);
                if (bill == null)
                {
                    return HttpNotFound();
                }
                ViewBag.idUser = new SelectList(db.Users, "idUser", "idPermission", bill.idUser);
                return View(bill);
            }
            return Redirect("~/Home");
        }

        // POST: Admin/Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idBill,idUser,Shipping,Total,PTTT,status,createdAt,totalQty,nameBook,email,phone,address")] Bill bill)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bill).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.idUser = new SelectList(db.Users, "idUser", "idPermission", bill.idUser);
                return View(bill);
            }
            return Redirect("~/Home");
        }

        // GET: Admin/Bills/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bill bill = db.Bills.Find(id);
                if (bill == null)
                {
                    return HttpNotFound();
                }
                return View(bill);
            }
            return Redirect("~/Home");
        }
        // POST: Admin/Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                Bill bill = db.Bills.Find(id);
                db.Bills.Remove(bill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Redirect("~/Home");
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





