using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.Models;

namespace Test_Application.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RolesAction(RolesModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("About", new { id = model.RoleId });
            }
            ;
            return View();
        }

        public ActionResult About()
        {


            return View();
        }


    }
}