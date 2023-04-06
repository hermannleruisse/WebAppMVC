using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class AboutController : Controller
    {
        // GET: ADMIN/About
        private readonly ApplicationDbContext context = ApplicationDbContext.getInstance();

        public ActionResult Index()
        {
            IList<About> abouts = context.Abouts.ToList();
            return View(abouts);
        }

        public ActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(About about)
        {
            if (!ModelState.IsValid)
            {
                return View("create");
            }

            try
            {
                using (var ctx = context)
                {
                    ctx.Abouts.Add(about);
                    ctx.SaveChanges();
                    TempData["Message"] = "Nouvel enrégistrement réussie avec succès !";
                }
            }
            catch (Exception exc)
            {
                ViewBag.Message = exc.Message;
                throw exc;
            }
            return RedirectToAction("Index");
        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }

            return View("edit", about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, About about)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            try
            {
                using (var ctx = context)
                {
                    var abt = ctx.Abouts.Find(id);

                    ctx.Entry(abt).State = EntityState.Modified;
                    if (TryUpdateModel(abt))
                        ctx.SaveChanges();

                    TempData["Message"] = "Mise à jour réussie avec succès !";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception exc)
            {
                ViewBag.Message = exc.Message;
                throw exc;
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }

            return View("detail", about);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about = context.Abouts.Find(id);
            if (about == null)
            {
                return HttpNotFound();
            }

            return View("delete", about);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Abouts.Remove(context.Abouts.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}