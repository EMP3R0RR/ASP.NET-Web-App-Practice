using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.Models;

namespace Test_Application.Controllers
{
    public class RegConController : Controller
    {
        // GET: RegCon
        public ActionResult FormPage() //calling the page for the form
        {
            return View();
        }

        //public ActionResult FormPageLoad(RegMod reg) //usage of models and form submission
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TempData["fname"]= reg.fname;
        //        TempData["lname"] = reg.lname;

        //        return RedirectToAction("Success", reg); //redirect to success page with reg object
        //    }
        //    return View(reg);
            
        //}

        //public ActionResult Success(RegMod reg) //success page takes the object reg and shows the view. 
        //{
        //    ViewBag.fname = TempData["fname"];
        //    ViewBag.lname = TempData["lname"];
        //    return View(reg);
        //}

        public ActionResult FormPageLoad(RegMod reg) //usage of models and form submission
        {
            if (ModelState.IsValid)
            {
                //TempData["fname"] = reg.fname;
                //TempData["lname"] = reg.lname;

                var regMod = new RegMod();
                regMod.fname = reg.fname;
                regMod.lname = reg.lname;

                TempData["fname"] = regMod.fname;
                TempData["lname"] = regMod.lname;

                return RedirectToAction("Success"); //redirect to success page with reg object
            }
            return View(reg);

        }

        public ActionResult Success() //success page takes the object reg and shows the view. 
        {
            ViewBag.fname = TempData["fname"];
            ViewBag.lname = TempData["lname"];
            return View();
        }




    }
}