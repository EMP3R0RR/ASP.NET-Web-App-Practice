using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.Models;

namespace Test_Application.Controllers
{
    public class FormValidationController : Controller
    {
        // GET: FormValidation
        [HttpGet]
        public ActionResult Form()
        {
            return View(new FormValidation());
        }

        [HttpPost]
        public ActionResult Form( FormValidation FV)
        {
            if (ModelState.IsValid)

            {
                TempData["formdata"] = FV;
                return RedirectToAction("Success");
            }
            return View(FV);
        }

        public ActionResult Success()
        {
            var formdata = TempData["formdata"] as FormValidation;
            return View(formdata);
        }
    }
}