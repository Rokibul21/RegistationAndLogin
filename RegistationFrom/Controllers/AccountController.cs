using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistationFrom.Models;

namespace RegistationFrom.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            using (OurDbContext db=new OurDbContext())
            {
                return View(db.UserAccounts.ToList());
            }
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db=new OurDbContext())
                {
                    db.UserAccounts.Add(userAccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = userAccount.FristName + " " + userAccount.LastName + " Successfully Register.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDbContext db = new OurDbContext())
            {
                try
                {
                    var usr = db.UserAccounts.SingleOrDefault(c => c.UserName == user.UserName && c.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserId"] = usr.UserId.ToString();
                        Session["UserName"] = usr.UserName.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User Name or Password is Wrong");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
               
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}