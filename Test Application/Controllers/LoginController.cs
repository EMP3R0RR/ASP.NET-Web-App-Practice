using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.EF;
using System.Security.Cryptography;
using System.Text;

namespace Test_Application.Controllers
{
    public class LoginController : Controller
    {
        TestDB2Entities db = new TestDB2Entities();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(string UserName, String Email, string Password , string ReturnUrl) {
            //Password = GetMd5Hash(Password);
            var user = (from u in db.Users
                        where u.UserName.Equals(UserName) &&
                        u.PasswordHashed.Equals(Password) &&
                        u.Email.Equals(Email)
                        select u).SingleOrDefault();
            if (user != null && user.UserType.Equals("Student"))
            {
                user.PasswordHashed = null;
                Session["User"] = user;
                if (ReturnUrl != null)
                {
                    return RedirectToAction("Index", "ProjectDetails");
                }
                return RedirectToAction("Details", "ProjectDetails");
            }
            TempData["Msg"] = "Username ,Password or Email Invalid";
            TempData["Class"] = "danger";
            return View();
        }

        static string GetMd5Hash(string input)
        {
            
            using (MD5 md5 = MD5.Create())
            {
              
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                
                byte[] hashBytes = md5.ComputeHash(inputBytes);

              
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));  

                return sb.ToString();
            }
        }
    }
}