using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.Models;
using Test_Application.EF;

namespace Test_Application.Controllers
{
    
    public class UserController : Controller
    {
        // GET: User

        ApplicationDBEntities1 db = new ApplicationDBEntities1();
        public ActionResult Create()

        {
            
            return View(new ApplicationDBEntities1());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create( UserData data)
        {
            db.UserDatas.Add(data);
            db.SaveChanges();
            
            return RedirectToAction("Details");
        }

        // GET: User/Details
        public ActionResult Details()
        {
            var data = db.UserDatas.ToList();
            return View(data);

        }
        //public ActionResult Details(int id)
        //{
        //    var data = db.UserDatas.Find(id);
        //    return View();

        //}
    }
}