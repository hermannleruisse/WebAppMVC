using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class DashboardController : Controller
    {
        // GET: ADMIN/Dashboard
        public ActionResult Index()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
    }
}