using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjektNET.WarstwaLogowanie;
using ProjektNET.BazaDanych;
using ProjektNET.ViewModels.Uwierzytelnianie;

namespace ProjektNET.Controllers
{
   
    public class UwierzytelnianieController : Controller
    {
        private DB db = new DB();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                WL appBL = new WL();
                if (appBL.isValidUser(vm))
                {
                    FormsAuthentication.SetAuthCookie(vm.username, false);
                    return Redirect("/Ksiazki/Index");
                }
                ModelState.AddModelError("CredentialError", "Podałeś błędną nazwę użytkownika lub hasło");
            }
            return View(vm);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Ksiazki/Index");
        }

        public ActionResult NewUser()
        {
            ViewBag.availability = true;
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(LoginVM newUser)
        {
            if (ModelState.IsValid)
            {
                WL appBL = new WL();
                if (!(ViewBag.availability = appBL.isUserNameAvailable(newUser.username)))
                    return View(newUser);
                newUser.password=newUser.hashPassword();
                db.adminsDB.Add(newUser);
                db.SaveChanges();
                return RedirectToAction("Login");

            }
            return View(newUser);
        }
    }
}