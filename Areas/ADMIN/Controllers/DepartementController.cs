using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class DepartementController : Controller
    {
        // GET: ADMIN/Departement
        private readonly ApplicationDbContext context;

        public DepartementController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            IList<Departement> departements = context.Departements.ToList();
            return View(departements);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement departement)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Departements.Add(departement);
                    ctx.SaveChanges();
                }
                ViewBag.Message = "Message envoyer avec succès !";
                return View("Index");
            }

            ViewBag.Message = "Echec d'envoie de message ";
            return View("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departement departement = context.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }

            return View("detail", departement);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departement departement = context.Departements.Find(id);
            if (departement == null)
            {
                return HttpNotFound();
            }

            return View("delete", departement);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Departements.Remove(context.Departements.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}