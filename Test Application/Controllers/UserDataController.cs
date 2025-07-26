using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.EF; // Ensure this namespace matches your EF context namespace

namespace Test_Application.Controllers
{
    public class UserDataController : Controller
    {
        //ApplicationDBEntities1 db =new ApplicationDBEntities1();
        //// GET: UserData
        //public ActionResult Index()
        //{
        //    var data = db.UserDatas.ToList();
        //    return View(data);
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        
        //public ActionResult Create(UserData s)
        //{
        //    db.UserDatas.Add(s);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public ActionResult Edit(int id)
        //{
        //    var data = db.UserDatas.Find(id); //searches with PK
        //    return View(data);
        //}
    }
}