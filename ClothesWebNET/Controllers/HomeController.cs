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
        public ActionResult Index()
        {
            string id = "T03";
            var productList = (from s in db.Products
                               where s.idType == id
                               select s);

            var query = productList.Include(p => p.ImageProducts);
            ViewBag.list = query.ToList();
            return View(query.ToList());

        }
        public ActionResult Address()
        {
            return View();

        }

        [HttpGet]

        public JsonResult GetUserInfo()
        {
            if (Session["USER_SESSION"] != null)
            {
                if (Request.Cookies["username"] != null)
                {
                    string username = Request.Cookies["username"].Value;

                    return this.Json(new
                    {
                        Result = (from obj in db.Users where obj.username == username select new { fullName = obj.fullName, email = obj.email, phone = obj.phone, password = obj.password, gender = obj.gender, indentity = obj.identityCard, address = obj.address, avt = obj.URLAvatar })
                    }, JsonRequestBehavior.AllowGet
                 );


                }
                else return Json("Xóa hết cookie và thử lại", JsonRequestBehavior.AllowGet);
            }
            return Json("Failed", JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyInfo()
        {

            if (Session["USER_SESSION"] != null)
            {
                if (Request.Cookies["username"] != null&& Request.Cookies["user"] != null)
                {
                    string username = Request.Cookies["username"].Value;
                    string user = Request.Cookies["user"].Value;
                    var data = (from u in db.Users where u.username == username select u);
                    return View(data.ToList());
                }
                else
                {
                    DeleteCookies();
                    return Redirect("/login");
                }
            }
            else return Redirect("/login");

        }


        [HttpPost]
        public ActionResult EditInfo(string fullName,string email,int phone,string address,int identityCard,string password)
        {

            if (Session["USER_SESSION"] != null)
            {
                if (Request.Cookies["username"] != null && Request.Cookies["user"] != null)
                {
                    string username = Request.Cookies["username"].Value;
                    string user = Request.Cookies["user"].Value;
                    db.Users.Find(user).fullName = fullName;

                  
                    db.Users.Find(user).email = email;


                    db.Users.Find(user).phone = phone;
                    db.Users.Find(user).address = address;
                    db.Users.Find(user).password = password;


                    db.SaveChanges();

                    return Redirect("/home/myinfo");
                }
                else
                {
                    DeleteCookies();
                    return Redirect("/login");
                }
            }
            else return Redirect("/login");

        }
        public void DeleteCookies()
        {
            Session["USER_SESSION"] = null;
            Session["SESSION_GROUP"] = null;

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                HttpCookie asp = Request.Cookies["ASP.NET_SessionId"];
                asp.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(asp);
                Session.Clear();

                HttpCookie us = Request.Cookies["username"];

                HttpCookie user = Request.Cookies["user"];


                if (us != null)
                {
                    us.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(us);
                }
                if(user != null)
                {
                    user.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(user);

                }


            }
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                Session.Clear();


                HttpCookie us = Request.Cookies["username"];

                HttpCookie user = Request.Cookies["user"];


                if (us != null)
                {
                    us.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(us);
                }
                if (user != null)
                {
                    user.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(user);

                }
                HttpCookie pass = Request.Cookies["password"];
                pass.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(pass);

            }
        }


        public ActionResult MyBill()
        {

            if (Session["USER_SESSION"] != null)
            {
                if (Request.Cookies["username"] != null && Request.Cookies["user"] != null)
                {
                   
                    string user = Request.Cookies["user"].Value;
                    var data = (from bill in db.Bills orderby bill.createdAt descending
                                where bill.idUser == user
                                select bill);
                    data.Include("DetailBill").Include("Product").Include("ImageProduct");




                    return View(data.ToList());
                }
                else
                {
                    DeleteCookies();
                    return Redirect("/login");
                }
            }
            else return Redirect("/login");

        }

    }
}