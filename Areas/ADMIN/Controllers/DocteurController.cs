using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class DocteurController : Controller
    {
        // GET: ADMIN/Docteur
        private readonly ApplicationDbContext context;
        public readonly string dir;

        public DocteurController(ApplicationDbContext context, string dir)
        {
            this.context = context;
            this.dir = dir;
        }

        public ActionResult Index()
        {
            IList<Docteur> docteurs = context.Docteurs.ToList();
            return View(docteurs);
        }
    }
}