using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext context = ApplicationDbContext.getInstance();

        // GET: ADMIN/Newsletter
        public ActionResult Index()
        {
            IList<Newsletter> newsletters = context.Newsletters.OrderByDescending(x => x.Date).ToList();
            return View(newsletters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = context)
                {
                    ctx.Newsletters.Add(newsletter);
                    ctx.SaveChanges();
                }
                ViewBag.Message = "Souscription envoyer avec succès !";
                return View("Index");
            }

            ViewBag.Message = "Echec d'envoie de message ";
            return View("Index");
        }


        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsletter newsletter = context.Newsletters.Find(id);
            if (newsletter == null)
            {
                return HttpNotFound();
            }

            return View("delete", newsletter);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Newsletters.Remove(context.Newsletters.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
