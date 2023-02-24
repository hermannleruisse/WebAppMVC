using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class SectionController : Controller
    {
        // GET: ADMIN/Section
        private readonly ApplicationDbContext context;

        public SectionController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            IList<Section> sections = context.Sections.ToList();
            return View(sections);
        }

        public ActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Section section)
        {
            if (!ModelState.IsValid)
            {
                return View("create");
            }

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Sections.Add(section);
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
            Section section = context.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }

            return View("edit", section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Section section)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var sec = ctx.Sections.Find(id);

                    ctx.Entry(sec).State = EntityState.Modified;
                    if (TryUpdateModel(sec))
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
            Section section = context.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }

            return View("detail", section);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = context.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }

            return View("delete", section);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Sections.Remove(context.Sections.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}