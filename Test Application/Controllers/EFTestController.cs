using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.EF;

namespace Test_Application.Controllers
{
    public class EFTestController : Controller
    {
        // GET: EFTest
        TestDB2Entities db = new TestDB2Entities();
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var data = db.Students.Find(id); //searches with PK
            return View(data);
        }
    }
}