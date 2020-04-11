using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectdeliverable.Models;

namespace projectdeliverable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Signup()
        {
            return View();
        }



        public ActionResult loginformfunction(string email, string password)
        {
            int result = CRUD.Login(email, password);

            if (result == -1)
            {
                string data = "Something went wrong while connecting with the database.";
                return View("Login", (object)data);
            }

            else if (result == 0)
            {
                string data = "Incorrect Credentials";
                return View("Login", (object)data);
            }

            return RedirectToAction("login");
        }

       public ActionResult signupfunction(string fname, string lname, char gender, string email, string password,  string phone, string dob, int seq, string qans)
        {
            int result = CRUD.signup(fname, lname, gender, email, password, phone, dob, seq, qans);

            if (result == -1)
            {
                string data = "Something went wrong while connecting with the database.";
                return View("Signup", (object)data);
            }

            else if (result == 0)
            {
                string data = "Email already exists";
                return View("Signup", (object)data);
            }

            return RedirectToAction("Signup");
        }
    }
}