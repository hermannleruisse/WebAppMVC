using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.DTO;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Connexion(AuthenticateRequest auth)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var us = ctx.Users.Where(x => x.Username.Equals(auth.Username) && x.Password.Equals(auth.Password)).FirstOrDefault();
                    if (us != null)
                    {
                        Session["UserId"] = us.Id;
                        Session["Username"] = us.Username;
                        Session["Role"] = us.Role;
                        Session.Timeout = 10;
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            ViewBag.Message = "Login ou mots de passe incorrecte";
            return View();
        }
    }
}