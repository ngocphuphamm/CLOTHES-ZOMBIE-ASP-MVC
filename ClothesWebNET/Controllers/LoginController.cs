using ClothesWebNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ClothesWebNET.Models.User;
using System.Data.Entity;


namespace ClothesWebNET.Controllers
{
    public class LoginController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();

        public ActionResult Index()
        {
            if (Session["USER_SESSION"] != null)
            {
                
                    return Redirect("~/Home");
                
                  
            }
            else
            {
                if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                {

                    ViewBag.username = Request.Cookies["username"].Value;
                    ViewBag.password = Request.Cookies["password"].Value;
                }

                return View();
            }
          
               
         


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
        //thêm hàm lưu hết thông tin trong cookies
        public void SaveInfoInCookies(string idUser,string username)
        {
            HttpCookie us = new HttpCookie("username");
     
            HttpCookie user = new HttpCookie("user");
            us.Value = username;
            user.Value = idUser;

            us.Expires = DateTime.Now.AddDays(1);
       
            user.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(us);
      
            Response.Cookies.Add(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult kiemtradangnhap(string username, string password, string ghinho)
        {
            var idUser = "";

            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                username = Request.Cookies["username"].Value;
                password = Request.Cookies["password"].Value;
            }
           
            if (checkpassword(username, password))
            {

                var infoUser = getInfoUser(username);
                var email= "";
                var  phone = 1;
                var fullName = "";
            
                for(var i = 0; i < infoUser.Count; i++)
                {
                    email = infoUser[i].email;
                    phone = infoUser[i].phone;
                    fullName = infoUser[i].fullName;
                    idUser = infoUser[i].userId;
                }
           

                var userSession = new UserLogin();
                userSession.UserName = username;
                userSession.fullName = fullName;
                userSession.phone = phone;  
                userSession.email = email;
                userSession.idUser = idUser; 
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
                
                    SaveInfoInCookies(idUser,username);
                    return Redirect("~/Admin/Dashboard/Index");
                }
                else
                {
                    Session.Add("SESSION_GROUP", listGroups);
                    Session.Add("USER_SESSION", userSession);
          
                    SaveInfoInCookies(idUser,username);
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
                            userId = s.idUser,  
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
       
        //thêm hàm xóa hết thông tin trong cookies
        private void DeleteCookies()
        {
            Session.Clear();

            HttpCookie us = Request.Cookies["username"];
       
            HttpCookie user = Request.Cookies["user"];


          
            us.Expires = DateTime.Now.AddDays(-1);
         
            user.Expires = DateTime.Now.AddDays(-1);

            Response.Cookies.Add(us);
     
        
            Response.Cookies.Add(user);
        }
        public ActionResult SignOut()
        {

            Session["USER_SESSION"] = null;
            Session["SESSION_GROUP"] = null;

             if(Request.Cookies["ASP.NET_SessionId"]!=null)
            {
                HttpCookie asp = Request.Cookies["ASP.NET_SessionId"];
                asp.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(asp);

                DeleteCookies();
            }
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null )
            {
                DeleteCookies();
                HttpCookie pass = Request.Cookies["password"];
                pass.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(pass);

            }
            
            return Redirect("/Home");
        }


       

    }

}