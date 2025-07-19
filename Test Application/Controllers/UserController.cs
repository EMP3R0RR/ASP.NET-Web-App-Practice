using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.Models;

namespace Test_Application.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Details", user);
            }
            return View(user);
        }

        // GET: User/Details
        public ActionResult Details(UserModel user)
        {
            return View(user);
        }
    }
}