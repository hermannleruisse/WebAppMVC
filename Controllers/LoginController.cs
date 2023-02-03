using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.DTO;
using WebAppMVC.Models;
using BCryptNet = BCrypt.Net.BCrypt;

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
                    String pass = BCryptNet.HashPassword(auth.Password);
                    var us = ctx.Users.Where(x => x.Username.Equals(auth.Username)).FirstOrDefault();
                    if (us != null && BCryptNet.Verify(auth.Password, us.Password))
                    {
                        Session["UserId"] = us.Id;
                        Session["Username"] = us.Username;
                        Session["Role"] = us.Role;
                        Session.Timeout = 2;
                        return RedirectToAction("Index", "Dashboard", new { area = "ADMIN" });
                    }
                }
            }
            ViewBag.Message = "Login ou mots de passe incorrecte";
            return View("Index");
        }
    }
}