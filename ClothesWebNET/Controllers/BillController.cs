using ClothesWebNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;



namespace ClothesWebNET.Controllers
{
    public class BillController : Controller
    {
        private CLOTHESEntities db = new CLOTHESEntities();
        // GET: Bill
        public ActionResult Index()

        {
            
            return View();
        }
      

        [HttpPost]
        public ActionResult PostBill(string idBill , string idUser,int Shipping , int Total , int totalQty,string nameBook ,string email , int phone,
                                    string address , string PTTT , DetailBIll []  detailBill ,bool status )
        {
            var idUserReal = "";      
            if(Request.Cookies["user"]!=null)
            {
                idUserReal = Request.Cookies["user"].Value;
         
            }
           var bill = new Bill()
            {
                idBill = idBill,
                idUser = idUserReal != "" ? idUserReal : null,
                createdAt = DateTime.Now,   
                Shipping = Shipping,
                Total = Total,
                totalQty = totalQty,
                nameBook = nameBook,
                email = email,
                phone = Convert.ToString(phone),
                address = address,
                PTTT = PTTT,
                status = status,
                DetailBIlls = detailBill ,
            };
            db.Bills.Add(bill);

           
            db.SaveChanges();
            return Json("Đặt hàng thành công");

        }

     

       
        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        public bool IsValidVietNamPhoneNumber(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum))
                return false;
            string sMailPattern = @"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$";
            return Regex.IsMatch(phoneNum.Trim(), sMailPattern);
        }

    }
}