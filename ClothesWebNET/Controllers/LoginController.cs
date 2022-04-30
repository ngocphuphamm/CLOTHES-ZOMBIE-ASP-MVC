using ClothesWebNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ClothesWebNET.Models.User;

namespace ClothesWebNET.Controllers
{
    public class LoginController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        public ActionResult Index()
        {
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.username = Request.Cookies["username"].Value;
                ViewBag.password = Request.Cookies["password"].Value;
            }
           
            return View();
        }

        public void ghinhotaikhoan(string username, string password)
        {
            HttpCookie us = new HttpCookie("username");
            HttpCookie pas = new HttpCookie("password");

            us.Value = username;
            pas.Value = password;

            us.Expires = DateTime.Now.AddDays(1);
            pas.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(us);
            Response.Cookies.Add(pas);

        }

        [HttpPost]
        public ActionResult kiemtradangnhap(string username, string password, string ghinho)
        {
            if (Request.Cookies["username"] != null && Request.Cookies["username"] != null)
            {
                username = Request.Cookies["username"].Value;
                password = Request.Cookies["password"].Value;
            }
            if (username == "admin" && password == "1234")
            {
                return Redirect("~/Admin/Dashboard/Index");
            }
            if (checkpassword(username, password))
            {
                var userSession = new UserLogin();
                userSession.UserName = username;

                var listGroups = GetListGroupID(username);//Có thể viết dòng lệnh lấy các GroupID từ CSDL, ví dụ gán ="ADMIN", dùng List<string>

                Session.Add("SESSION_GROUP", listGroups);
                Session.Add("USER_SESSION", userSession);

                if (ghinho == "on")//Ghi nhớ
                    ghinhotaikhoan(username, password);
                return Redirect("~/Home");

            }
            return Redirect("~/Login");
        }
        public List<string> GetListGroupID(string userName)
        {
            // var user = db.User.Single(x => x.UserName == userName);

            var data = (from a in db.Permissions
                        join b in db.Users on a.idPermission equals b.idPermission
                        where b.username == userName

                        select new
                        {
                            UserGroupID = b.idPermission,
                            UserGroupName = a.namePermission
                        });

            return data.Select(x => x.UserGroupName).ToList();

        }
        public bool checkpassword(string username, string password)
        {
            if (db.Users.Where(x => x.username == username && x.password == password).Count() > 0)

                return true;
            else
                return false;


        }

        public ActionResult SignOut()
        {

            Session["USER_SESSION"] = null;
            Session["SESSION_GROUP"] = null;


            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                HttpCookie us = Request.Cookies["username"];
                HttpCookie ps = Request.Cookies["password"];

                ps.Expires = DateTime.Now.AddDays(-1);
                us.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(us);
                Response.Cookies.Add(ps);
            }

            return Redirect("/Home");
        }

    }

}