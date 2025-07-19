using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_Application.Models;

namespace Test_Application.Controllers
{
    public class RegistrationController : Controller
    {
        // the sole purpose of this controller is to learn how to create a registration form
        // demonstrate the use of the registration form handling in asp.net and to show
        // how a registration form validation works in asp.net mvc
        public ActionResult Register()
        {
            return View();
        }

        // POST: Handle the form submission manually
        [HttpPost]
        public ActionResult RegisterForm(FormCollection form)
        {
            // Getting form data 
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            // Manual validation ( isnull or empty checks  name is empty or not, takes one parameter like name,email and password)
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "All fields are required."; //passing the error message to the view
                return RedirectToAction("Register");
            }

            // Created a UserModel object to pass to the profile view
            UserModel user = new UserModel
            {
                Name = name, // Name from model to be stored into name variable
                Email = email,
                Password = password
            };

            // Store the user object in TempData to pass it to the next view
            TempData["User"] = user;

            return RedirectToAction("Profile");
        }

        // GET: Show the profile with data
        public ActionResult Profile()
        {
            UserModel user = TempData["User"] as UserModel;
            if (user == null)
            {
                return RedirectToAction("Register");
            }

            return View(user);
        }
    }
}