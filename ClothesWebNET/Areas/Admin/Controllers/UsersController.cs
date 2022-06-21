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
    public class UsersController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        // GET: Admin/Users
        public ActionResult Index()
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                var users = db.Users.Include(u => u.Permission);
                return View(users.ToList());
            }
            return Redirect("~/login");
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            return Redirect("~/login");
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                ViewBag.idPermission = new SelectList(db.Permissions, "idPermission", "namePermission");
                return View();
            }
            return Redirect("~/login");
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUser,idPermission,fullName,username,password,gender,identityCard,address,email,URLAvatar,phone")] User user)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (ModelState.IsValid)
                {
                    int count = db.Users.Count() + 1;

                    var id = 'U' + count.ToString();
                    user.idUser = id;

                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index"); ;
                }

                ViewBag.idPermission = new SelectList(db.Permissions, "idPermission", "namePermission", user.idPermission);
                return View(user);
            }
            return Redirect("~/login");
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.idPermission = new SelectList(db.Permissions, "idPermission", "namePermission", user.idPermission);
                return View(user);
            }
            return Redirect("~/login");
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUser,idPermission,username,fullName,password,gender,identityCard,address,email,URLAvatar,phone")] User user)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.idPermission = new SelectList(db.Permissions, "idPermission", "namePermission", user.idPermission);
                return View(user);
            }
            return Redirect("~/login");
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            return Redirect("~/login");
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["SESSION_GROUP_ADMIN"] != null)
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Redirect("~/login");
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