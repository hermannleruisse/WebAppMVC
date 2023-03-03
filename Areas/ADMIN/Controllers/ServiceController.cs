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
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext context;

        public ServiceController()
        {
            context = new ApplicationDbContext();
        }

        // GET: ADMIN/Service

        public ActionResult Index()
        {
            IList<Service> services = context.Services.ToList();
            return View(services);
        }

        public ActionResult Create()
        {
            return View("create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("create");
            }
            
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Services.Add(service);
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
            Service service = context.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            return View("edit", service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Service service)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var ser = ctx.Services.Find(id);

                    ctx.Entry(ser).State = EntityState.Modified;
                    if (TryUpdateModel(ser))
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
            Service service = context.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            return View("detail", service);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = context.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            return View("delete", service);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Services.Remove(context.Services.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}