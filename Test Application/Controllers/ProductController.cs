using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.EF;

namespace Test_Application.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        TestDB2Entities db = new TestDB2Entities();
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create( Product P)
        {
            
            db.Products.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Products.Find(id);
            
            return View(data);
        }

        public ActionResult Edit(Product p)
        {
            var data = db.Products.Find(p.Id);

            data.Name = p.Name;

            data.Price = p.Price;

            data.Qty = p.Qty;

            data.Description = p.Description;

            db.SaveChanges();


            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id) 
        {
            if (id != null) {

                var data = db.Products.Find(id);
                return View(data);
            }

            return View();
            
        }


        [HttpPost]
        public ActionResult Delete (Product p)
        {
            var data = db.Products.Find(p.Id);
            if (data != null)
            {
                db.Products.Remove(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}