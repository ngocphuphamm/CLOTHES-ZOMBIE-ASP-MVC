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
           /* if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                if (Session["SESSION_GROUP_ADMIN"] != null)
                {
                    return Redirect("~/Admin/Dashboard/Index");
                }
                else
                {
                    return Redirect("~/Home");
                }
                  
            }
            else
            {*/
                if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                {

                    ViewBag.username = Request.Cookies["username"].Value;
                    ViewBag.password = Request.Cookies["password"].Value;
                }

                return View();
     /*       }*/
          
               
         


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
           
            if (checkpassword(username, password))
            {

                var infoUser = getInfoUser(username);
                var email= "";
                var phone = 1;
                var fullName = "";
                for(var i = 0; i < infoUser.Count; i++)
                {
                    email = infoUser[i].email;
                    phone = infoUser[i].phone;
                    fullName = infoUser[i].fullName;    
                }
           

                var userSession = new UserLogin();
                userSession.UserName = username;
                userSession.fullName = fullName;
                userSession.phone = phone;  
                userSession.email = email;

                var group = "";
                var listGroups = GetListGroupID(username);//Có thể viết dòng lệnh lấy các GroupID từ CSDL, ví dụ gán ="ADMIN", dùng List<string>
             
                if (ghinho == "on")//Ghi nhớ
                    ghinhotaikhoan(username, password);

                for (var i = 0; i < listGroups.Count; i++)
                {
                    group = listGroups[i];
                }
                if (group == "Admin")
                {
                    // namePermission
                    Session.Add("SESSION_GROUP_ADMIN", listGroups);
                    Session.Add("USER_SESSION", userSession);
                    return Redirect("~/Admin/Dashboard/Index");
                }
                else
                {
                    Session.Add("SESSION_GROUP", listGroups);
                    Session.Add("USER_SESSION", userSession);
                    return Redirect("~/Home");
                }

            }
            return Redirect("~/Login");
        }

        public List<getUserDTO> getInfoUser (string userName)
        {
            // var user = db.User.Single(x => x.UserName == userName);
            getUserDTO getUserDTO = new getUserDTO();
            var data = (from s in db.Users
                        where s.username == userName
                        select new getUserDTO
                        {
                            fullName = s.fullName , 
                            email = s.email ,   
                            phone = s.phone 
                        });

            return data.ToList();

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
/*            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));*/
             if(Request.Cookies["ASP.NET_SessionId"]!=null)
            {
                HttpCookie asp = Request.Cookies["ASP.NET_SessionId"];
                asp.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(asp);
            }
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null )
            {

                Session.Clear();
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