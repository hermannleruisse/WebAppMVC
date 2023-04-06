using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Areas.ADMIN.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext context = ApplicationDbContext.getInstance();

        // GET: ADMIN/Appointment
        public ActionResult Index()
        {
            IList<Appointment> appointments = context.Appointments.OrderByDescending(x => x.Date).ToList();
            return View(appointments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                using (var ctx = context)
                {
                    ctx.Appointments.Add(appointment);
                    ctx.SaveChanges();
                }
                ViewBag.Message = "Votre requête à été soumise. Merci!";
                return View("Index");
            }

            ViewBag.Message = "Votre requête n'à pas été soumise. Réessayer !";
            return View("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View("detail", appointment);
        }

        public ActionResult QuestionDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            return View("delete", appointment);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            context.Appointments.Remove(context.Appointments.Find(id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}