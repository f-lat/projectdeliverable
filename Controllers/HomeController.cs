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
            if (Session["email"] == null)
                return View();
            else
                return View("inbox");
        }

        public ActionResult Signup()
        {
            if (Session["email"] == null)
                return View();
            else
                return View("inbox");
        }

        public ActionResult editprofile()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult forgotpass()
        {
            if (Session["email"] == null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult drafts()
        {
            if (Session["email"]!= null )
            {
                string currentuser = Session["email"].ToString();
                List<emailitem> draftsmail = CRUD.showdrafts(currentuser);
                return View(draftsmail);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult logout()
        {
            if (Session["email"]!=null)
            {
                Session["email"] = null;
                return View("Login");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult forgotpassword(string email, string answer, string newpass)
        {
            int result = CRUD.forgotpassword(email, answer, newpass);
            if (result == 0)
            {
                string data = "Successful!";
                return View("forgotpass", (object)data);
            }
            else if (result == -1)
            {
                string data = "email not found !";
                return View("forgotpass", (object)data);
            }
            else if (result == -2)
            {
                string data = "incorrect answer !";
                return View("forgotpass", (object)data);
            }
            else if (result == -3)
            {
                string data = "database error !";
                return View("forgotpass", (object)data);
            }
            return View("forgotpass");
        }


        public ActionResult manage()
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                customlists r = new customlists();
                r.block = CRUD.showblockedusers(currentuser);
                r.spam = CRUD.showspammers(currentuser);
                return View(r);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult sdel(string id)
        {
            string currentuser = Session["email"].ToString();
            int r1 = CRUD.delspammer(currentuser, id);
            customlists r = new customlists();
            r.block = CRUD.showblockedusers(currentuser);
            r.spam = CRUD.showspammers(currentuser);
            return View("manage",r);
        }

        public ActionResult bdel(string id)
        {
            string currentuser = Session["email"].ToString();
            int r1 = CRUD.delblocked(currentuser, id);
            customlists r = new customlists();
            r.block = CRUD.showblockedusers(currentuser);
            r.spam = CRUD.showspammers(currentuser);
            return View("manage", r);
        }

        public ActionResult block()
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                List<emailitem> blockmails = CRUD.showblock(currentuser);
                return View(blockmails);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult newmail()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult profile()
        {
            if (Session["email"]!= null)
            {
                string currentuser = Session["email"].ToString();
                List<user> t = CRUD.showuser(currentuser);
                return View(t);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult spam()
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                List<emailitem> spammails = CRUD.showspam(currentuser);
                return View(spammails);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult trash()
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                List<emailitem> trashmails = CRUD.showtrash(currentuser);
                return View(trashmails);
            }
            else
                return View("Login");
        }

        public ActionResult del(string mailid)
        {
            string currentuser = Session["email"].ToString();
            CRUD.delmail(currentuser, mailid);
            return View();
        }

        public ActionResult inbox()
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                List<emailitem> inboxmails = CRUD.showinbox(currentuser);
                return View(inboxmails);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult sent()
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                List<emailitem> sentmails = CRUD.showsent(currentuser);
                return View(sentmails);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult blockid(string blocked)
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                CRUD.blockid(currentuser, blocked);
                customlists r = new customlists();
                r.block = CRUD.showblockedusers(currentuser);
                r.spam = CRUD.showspammers(currentuser);
                return View("manage",r);
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult spamid(string spammer)
        {
            if (Session["email"] != null)
            {
                string currentuser = Session["email"].ToString();
                CRUD.spamid(currentuser, spammer);
                customlists r = new customlists();
                r.block = CRUD.showblockedusers(currentuser);
                r.spam = CRUD.showspammers(currentuser);
                return View("manage", r);
            }
            else
            {
                return View("Login");
            }
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

            else
            {
                Session["email"] = email;
                return RedirectToAction("inbox");
            }
        }

        public ActionResult signupfunction(string fname, string lname, char gender, string email, string password, string phone, DateTime dob, int seq, string qans)
        {
            int result = CRUD.signup(fname, lname, gender, email, password, phone, dob, seq, qans);

            if (result == -1)
            {
                string data = "Email exists.";
                return View("Signup", (object)data);
            }

            else if (result == -2)
            {
                string data = "Something went wrong with the database connection";
                return View("Signup", (object)data);
            }

            else if (result == 0)
            {
                string data = "Account Created";
                return View("Login", (object)data);
            }

            return RedirectToAction("Signup");
        }

        public ActionResult sendmail(string receiver, string subject, string content, string isdraft)
        {
            if (isdraft == "d")
            {
                string currentuser = Session["email"].ToString();
                CRUD.savedraft(currentuser, receiver, subject, content);
                return View("newmail");
            }
            else
            {
                string currentuser = Session["email"].ToString();
                CRUD.sendmail(currentuser, receiver, subject, content);
                return View("newmail");
            }
        }

        public ActionResult edit(string fname, string lname, DateTime dob, string phone, string pass)
        {
            string currentuser = Session["email"].ToString();
            int result = CRUD.editp(currentuser, fname, lname, phone, dob, pass);

            if (result== 1)
            {
                string data = "Profile Changed !";
                return View("editprofile", (object)data);
            }
            else
            {
                string data = "wrong Password !";
                return View("editprofile", (object)data);
            }
        }


    }
}